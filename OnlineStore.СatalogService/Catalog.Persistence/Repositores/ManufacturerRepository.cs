using Catalog.Domain;
using Catalog.Domain.Entities;
using Catalog.Persistence.Abstractions.Interfaces;
using Catalog.Persistence.Exceptions;
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
            var addResult = await _dbContext.Manufacturer.AddAsync(manufacturer);
            
            if (addResult.State is not EntityState.Added) 
            {                
                return new RepositoryResult(false, new ManufacturerStateException(addResult.State.ToString()));
            }

            await _dbContext.SaveChangesAsync();

            return new RepositoryResult(true);
        }

        public async Task<IEnumerable<Manufacturer>> GetAllAsync(int pageSize, int pageNumber, CancellationToken cancellationToken)
        {
            var listOfManufacturers = await _dbContext.Manufacturer
                .Skip(pageSize * (pageNumber - 1))
                .Take(pageSize)
                .OrderByDescending(m => m.Title)
                .ToListAsync();

            return listOfManufacturers;
        }

        public async Task<Manufacturer?> FindByIdAsync(Guid manufacturerId, CancellationToken cancellationToken)
        {
            var manufacturer = await _dbContext.Manufacturer.AsTracking().FirstOrDefaultAsync(manufacturer => manufacturer.Id == manufacturerId);

            return manufacturer;
        }

        public async Task<Manufacturer?> FindByTitleAsync(string manufacturerTitle, CancellationToken cancellationToken)
        {
            var manufacturer = await _dbContext.Manufacturer.FirstOrDefaultAsync(manufacturer => manufacturer.Title == manufacturerTitle);

            return manufacturer;
        }

        public async Task<RepositoryResult> ChangeTitleAsync(Manufacturer manufacturer, string newTitle, CancellationToken cancellationToken)
        {
            manufacturer.Title = newTitle;

            await _dbContext.SaveChangesAsync();

            return new RepositoryResult(true);
        }

        public async Task<RepositoryResult> DeleteAsync(Manufacturer manufacturer, CancellationToken cancellationToken)
        {
            await ResetManufacturer(manufacturer);

            var deleteResult = _dbContext.Manufacturer.Remove(manufacturer);

            if (deleteResult.State is not EntityState.Deleted)
            {
                return new RepositoryResult(false, new ManufacturerStateException(deleteResult.State.ToString()));
            }

            await _dbContext.SaveChangesAsync();

            return new RepositoryResult(true);
        }

        private async Task ResetManufacturer(Manufacturer manufacturer)
        {
            await _dbContext.Entry(manufacturer)
            .Collection(m => m.Products)
            .LoadAsync();

            foreach (var product in manufacturer.Products)
            {
                product.ManufacturerId = null;
            }
        }
    }
}