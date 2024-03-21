using Catalog.Domain.Entities;
using Catalog.Persistence.Abstractions.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Persistence.Repositores
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        private readonly СatalogDbContext _dbContext;

        public ProductRepository(СatalogDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Product>> GetPageAsync(int pageSize, int pageNumber, Guid categoryId, List<Guid> manufacturerIds, CancellationToken cancellationToken)
        {
            var query = _dbContext.Products.AsNoTracking();

            if (categoryId != Guid.Empty)
            {
                query = query.Where(p => p.CategoryId == categoryId);
            }

            if (manufacturerIds.Count != 0)
            {
                query = query.Where(p => manufacturerIds.Contains(p.ManufacturerId.Value));
            }

            query = query
                .Skip(pageSize * (pageNumber - 1))
                .Take(pageSize)
                .OrderByDescending(m => m.Title);

            return await query.ToListAsync(cancellationToken);
        }

        public async Task<Product?> FindByTitleAsync(string productTitle, CancellationToken cancellationToken)
        {
            var product = await _dbContext.Products.FirstOrDefaultAsync(product => product.Title == productTitle, cancellationToken);

            return product;
        }
    }
}