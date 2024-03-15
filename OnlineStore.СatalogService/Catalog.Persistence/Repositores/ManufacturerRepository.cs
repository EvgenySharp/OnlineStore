using Catalog.Domain.Entities;
using Catalog.Persistence.Abstractions.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Persistence.Repositores
{
    public class ManufacturerRepository : BaseRepository<Manufacturer>, IManufacturerRepository
    {
        private readonly СatalogDbContext _dbContext;

        public ManufacturerRepository(СatalogDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Manufacturer>> GetPageAsync(int pageSize, int pageNumber, CancellationToken cancellationToken)
        {
            var listOfManufacturers = await _dbContext.Manufacturers
                .AsNoTracking()
                .Skip(pageSize * (pageNumber - 1))
                .Take(pageSize)
                .OrderByDescending(m => m.Title)
                .ToListAsync(cancellationToken);

            return listOfManufacturers;
        }

        public async Task<Manufacturer?> FindByTitleAsync(string manufacturerTitle, CancellationToken cancellationToken)
        {
            var manufacturer = await _dbContext.Manufacturers.FirstOrDefaultAsync(manufacturer => manufacturer.Title == manufacturerTitle, cancellationToken);

            return manufacturer;
        }

        public override async Task<RepositoryResult> DeleteAsync(Manufacturer manufacturer, CancellationToken cancellationToken)
        {
            await ResetManufacturer(manufacturer, cancellationToken);

            return await base.DeleteAsync(manufacturer, cancellationToken);
        }

        private async Task ResetManufacturer(Manufacturer manufacturer, CancellationToken cancellationToken)
        {
            await _dbContext.Entry(manufacturer)
                .Collection(m => m.Products)
                .LoadAsync(cancellationToken);

            foreach (var product in manufacturer.Products)
            {
                product.ManufacturerId = null;
            }
        }
    }
}