using Azure.Core;
using Catalog.Domain;
using Catalog.Domain.Entities;
using Catalog.Persistence.Abstractions.Interfaces;
using Catalog.Persistence.Exceptions;
using Microsoft.AspNetCore.JsonPatch;
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
            var addResult = await _dbContext.Products.AddAsync(product, cancellationToken);

            if (addResult.State is not EntityState.Added)
            {
                return new RepositoryResult(false, new ProductStateException(addResult.State.ToString()));
            }

            await SaveChangesAsync(cancellationToken);

            return new RepositoryResult(true);
        }

        public async Task<IEnumerable<Product>> GetAllAsync(int pageSize, int pageNumber, CancellationToken cancellationToken)
        {
            var listOfProducts = await _dbContext.Products
                .AsNoTracking()
                .Skip(pageSize * (pageNumber - 1))
                .Take(pageSize)
                .OrderByDescending(m => m.Title)
                .ToListAsync(cancellationToken);

            return listOfProducts;
        }

        public async Task<Product?> FindByIdAsync(Guid productId, CancellationToken cancellationToken)
        {
            var product = await _dbContext.Products.AsTracking().FirstOrDefaultAsync(product => product.Id == productId, cancellationToken);

            return product;
        }

        public async Task<Product?> FindByTitleAsync(string productTitle, CancellationToken cancellationToken)
        {
            var product = await _dbContext.Products.FirstOrDefaultAsync(product => product.Title == productTitle, cancellationToken);

            return product;
        }

        public async Task<RepositoryResult> UpdateAsync(Product product, JsonPatchDocument<Product> request, CancellationToken cancellationToken)
        {
            request.ApplyTo(product);

            await SaveChangesAsync(cancellationToken);

            return new RepositoryResult(true);
        }

        public async Task<RepositoryResult> DeleteAsync(Product product, CancellationToken cancellationToken)
        {
            var deleteResult = _dbContext.Products.Remove(product);

            if (deleteResult.State is not EntityState.Deleted)
            {
                return new RepositoryResult(false, new ProductStateException(deleteResult.State.ToString()));
            }

            await SaveChangesAsync(cancellationToken);

            return new RepositoryResult(true);
        }

        private async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}