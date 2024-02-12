using Catalog.Domain;
using Catalog.Domain.Entities;
using Catalog.Persistence.Abstractions.Interfaces;
using Catalog.Persistence.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Persistence.Repositores
{
    public class ProductRepository : IProductRepository
    {
        private readonly СatalogDbContext _dbContext;

        public ProductRepository(СatalogDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<RepositoryResult> CreateAsync(Product product, CancellationToken cancellationToken)
        {
            var addResult = await _dbContext.Product.AddAsync(product);

            if (addResult.State is not EntityState.Added)
            {
                return new RepositoryResult(false, new ProductStateException(addResult.State.ToString()));
            }

            await _dbContext.SaveChangesAsync();

            return new RepositoryResult(true);
        }

        public async Task<IEnumerable<Product>> GetAllAsync(int pageSize, int pageNumber, CancellationToken cancellationToken)
        {
            var listOfProducts = await _dbContext.Product
                .Skip(pageSize * (pageNumber - 1))
                .Take(pageSize)
                .OrderByDescending(m => m.Title)
                .ToListAsync();

            return listOfProducts;
        }

        public async Task<Product?> FindByIdAsync(Guid productId, CancellationToken cancellationToken)
        {
            var product = await _dbContext.Product.AsTracking().FirstOrDefaultAsync(product => product.Id == productId);

            return product;
        }

        public async Task<Product?> FindByTitleAsync(string productTitle, CancellationToken cancellationToken)
        {
            var product = await _dbContext.Product.FirstOrDefaultAsync(product => product.Title == productTitle);

            return product;
        }

        public async Task<RepositoryResult> ChangeTitleAsync(Product product, string newTitle, CancellationToken cancellationToken)
        {
            product.Title = newTitle;

            await _dbContext.SaveChangesAsync();

            return new RepositoryResult(true);
        }

        public async Task<RepositoryResult> ChangeCategoryIdAsync(Product product, Guid newCategoryId, CancellationToken cancellationToken)
        {
            product.CategoryId = newCategoryId;

            await _dbContext.SaveChangesAsync();

            return new RepositoryResult(true);
        }

        public async Task<RepositoryResult> ChangeManufacturerIdAsync(Product product, Guid newManufacturerId, CancellationToken cancellationToken)
        {
            product.ManufacturerId = newManufacturerId;

            await _dbContext.SaveChangesAsync();

            return new RepositoryResult(true);
        }

        public async Task<RepositoryResult> DeleteAsync(Product product, CancellationToken cancellationToken)
        {
            var deleteResult = _dbContext.Product.Remove(product);

            if (deleteResult.State is not EntityState.Deleted)
            {
                return new RepositoryResult(false, new ProductStateException(deleteResult.State.ToString()));
            }

            await _dbContext.SaveChangesAsync();

            return new RepositoryResult(true);
        }
    }
}