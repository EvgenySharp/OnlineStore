using Catalog.Domain;
using Catalog.Domain.Entities;
using Catalog.Persistence.Abstractions.Interfaces;
using Catalog.Persistence.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Persistence.Repositores
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly СatalogDbContext _dbContext;

        public CategoryRepository(СatalogDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<RepositoryResult> CreateAsync(Category category, CancellationToken cancellationToken)
        {
            var addResult = await _dbContext.Category.AddAsync(category);

            if (addResult.State is not EntityState.Added)
            {
                return new RepositoryResult(false, new CategoryStateException(addResult.State.ToString()));
            }

            await _dbContext.SaveChangesAsync();

            return new RepositoryResult(true);
        }

        public async Task<IEnumerable<Category>> GetAllAsync(int pageSize, int pageNumber, CancellationToken cancellationToken)
        {
            var listOfCategory = await _dbContext.Category
                .Skip(pageSize * (pageNumber - 1))
                .Take(pageSize)
                .OrderByDescending(c => c.Title)
                .ToListAsync();

            return listOfCategory;
        }

        public async Task<Category?> FindByIdAsync(Guid categoryId, CancellationToken cancellationToken)
        {
            var category = await _dbContext.Category.AsTracking().FirstOrDefaultAsync(category => category.Id == categoryId);

            return category;
        }

        public async Task<Category?> FindByTitleAsync(string categoryTitle, CancellationToken cancellationToken)
        {
            var category = await _dbContext.Category.FirstOrDefaultAsync(category => category.Title == categoryTitle);

            return category;
        }

        public async Task<RepositoryResult> ChangeTitleAsync(Category category, string newTitle, CancellationToken cancellationToken)
        {
            category.Title = newTitle;

            await _dbContext.SaveChangesAsync();

            return new RepositoryResult(true);
        }

        public async Task<RepositoryResult> DeleteAsync(Category category, CancellationToken cancellationToken)
        {
            await ResetCategory(category);

            var deleteResult = _dbContext.Category.Remove(category);

            if (deleteResult.State is not EntityState.Deleted)
            {
                return new RepositoryResult(false, new CategoryStateException(deleteResult.State.ToString()));
            }

            await _dbContext.SaveChangesAsync();

            return new RepositoryResult(true);
        }

        private async Task ResetCategory(Category category)
        {
            await _dbContext.Entry(category)
                .Collection(m => m.Products)
                .LoadAsync();

            foreach (var product in category.Products)
            {
                product.ManufacturerId = null;
            }
        }
    }
}