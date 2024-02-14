using Catalog.Domain;
using Catalog.Domain.Entities;
using Catalog.Persistence.Abstractions.Interfaces;
using Catalog.Persistence.Exceptions;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Persistence.Repositores
{
    public class ManufacturerRepository : IManufacturerRepository
    {
        private readonly СatalogDbContext _dbContext;

        public ManufacturerRepository(СatalogDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<RepositoryResult> CreateAsync(Manufacturer manufacturer, CancellationToken cancellationToken)
        {
            var addResult = await _dbContext.Manufacturers.AddAsync(manufacturer, cancellationToken);
            
            if (addResult.State is not EntityState.Added) 
            {                
                return new RepositoryResult(false, new ManufacturerStateException(addResult.State.ToString()));
            }

            await SaveChangesAsync(cancellationToken);

            return new RepositoryResult(true);
        }

        public async Task<IEnumerable<Manufacturer>> GetAllAsync(int pageSize, int pageNumber, CancellationToken cancellationToken)
        {
            var listOfManufacturers = await _dbContext.Manufacturers
                .AsNoTracking()
                .Skip(pageSize * (pageNumber - 1))
                .Take(pageSize)
                .OrderByDescending(m => m.Title)
                .ToListAsync(cancellationToken);

            return listOfManufacturers;
        }

        public async Task<Manufacturer?> FindByIdAsync(Guid manufacturerId, CancellationToken cancellationToken)
        {
            var manufacturer = await _dbContext.Manufacturers.AsTracking().FirstOrDefaultAsync(manufacturer => manufacturer.Id == manufacturerId, cancellationToken);

            return manufacturer;
        }

        public async Task<Manufacturer?> FindByTitleAsync(string manufacturerTitle, CancellationToken cancellationToken)
        {
            var manufacturer = await _dbContext.Manufacturers.FirstOrDefaultAsync(manufacturer => manufacturer.Title == manufacturerTitle, cancellationToken);

            return manufacturer;
        }

        public async Task<RepositoryResult> UpdateAsync(Manufacturer manufacturer, JsonPatchDocument<Manufacturer> request, CancellationToken cancellationToken)
        {
            request.ApplyTo(manufacturer);

            await SaveChangesAsync(cancellationToken);

            return new RepositoryResult(true);
        }

        public async Task<RepositoryResult> DeleteAsync(Manufacturer manufacturer, CancellationToken cancellationToken)
        {
            await ResetManufacturer(manufacturer, cancellationToken);

            var deleteResult = _dbContext.Manufacturers.Remove(manufacturer);

            if (deleteResult.State is not EntityState.Deleted)
            {
                return new RepositoryResult(false, new ManufacturerStateException(deleteResult.State.ToString()));
            }

            await SaveChangesAsync(cancellationToken);

            return new RepositoryResult(true);
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

        private async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}