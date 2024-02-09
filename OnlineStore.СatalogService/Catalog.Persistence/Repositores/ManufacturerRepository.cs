using Catalog.Domain;
using Catalog.Domain.Entities;
using Catalog.Persistence.Abstractions.Interfaces;
using Catalog.Persistence.Exceptions.Manufacturer;
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

        public async Task<RepositoryResult> CreateAsync(Manufacturer manufacturer)
        {
            var addResult = await _dbContext.Manufacturer.AddAsync(manufacturer);
            
            if (addResult.State is not EntityState.Added) 
            {                
                return new RepositoryResult(false, new ManufacturerStateException(addResult.State.ToString()));
            }

            await _dbContext.SaveChangesAsync();

            return new RepositoryResult(true);
        }

        public async Task<Manufacturer?> FindByTitleAsync(string manufacturerTitle)
        {
            var manufacturer = await _dbContext.Manufacturer.FirstOrDefaultAsync(manufacturer => manufacturer.Title == manufacturerTitle);

            return manufacturer;
        }

        public async Task<Manufacturer?> FindByIdAsync(Guid manufacturerId)
        {
            var manufacturer = await _dbContext.Manufacturer.FirstOrDefaultAsync(manufacturer => manufacturer.Id == manufacturerId);

            return manufacturer;
        }

        public async Task<IEnumerable<Manufacturer>> GetAllAsync()
        {
            var listOfManufacturers = await _dbContext.Manufacturer.ToListAsync();

            return listOfManufacturers;
        }

        public async Task<RepositoryResult> ChangeTitleAsync(Manufacturer manufacturer, string mewTitle)
        {
            throw new NotImplementedException();
        }

        public async Task<RepositoryResult> DeleteAsync(Manufacturer manufacturer)
        {
            throw new NotImplementedException();
        }
    }
}