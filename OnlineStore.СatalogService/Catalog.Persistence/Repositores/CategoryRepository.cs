using Catalog.Domain.Entities;
using Catalog.Persistence.Abstractions.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Persistence.Repositores
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        private readonly СatalogDbContext _dbContext;

        public CategoryRepository(СatalogDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Category>> GetPageAsync(int pageSize, int pageNumber, CancellationToken cancellationToken)
        {
            var listOfCategory = await _dbContext.Categories
                .AsNoTracking()
                .Skip(pageSize * (pageNumber - 1))
                .Take(pageSize)
                .OrderByDescending(c => c.Title)
                .ToListAsync(cancellationToken);

            return listOfCategory;
        }

        public async Task<Category?> FindByTitleAsync(string categoryTitle, CancellationToken cancellationToken)
        {
            var category = await _dbContext.Categories.FirstOrDefaultAsync(category => category.Title == categoryTitle, cancellationToken);

            return category;
        }

        public override async Task<RepositoryResult> DeleteAsync(Category category, CancellationToken cancellationToken)
        {
            await ResetCategory(category, cancellationToken);

            return await base.DeleteAsync(category, cancellationToken);
        }

        private async Task ResetCategory(Category category, CancellationToken cancellationToken)
        {
            await _dbContext.Entry(category)
                .Collection(c => c.Products)
                .LoadAsync(cancellationToken);

            foreach (var product in category.Products)
            {
                product.ManufacturerId = null;
            }
        }
    }
}