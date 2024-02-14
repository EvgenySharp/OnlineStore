using Catalog.Domain;
using Catalog.Domain.Entities;
using Catalog.Persistence.Abstractions.Interfaces;
using Catalog.Persistence.Exceptions;
using Microsoft.AspNetCore.JsonPatch;
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
            var addResult = await _dbContext.Categories.AddAsync(category, cancellationToken);

            if (addResult.State is not EntityState.Added)
            {
                return new RepositoryResult(false, new CategoryStateException(addResult.State.ToString()));
            }

            await SaveChangesAsync(cancellationToken);

            return new RepositoryResult(true);
        }

        public async Task<IEnumerable<Category>> GetAllAsync(int pageSize, int pageNumber, CancellationToken cancellationToken)
        {
            var listOfCategory = await _dbContext.Categories
                .AsNoTracking()
                .Skip(pageSize * (pageNumber - 1))
                .Take(pageSize)
                .OrderByDescending(c => c.Title)
                .ToListAsync(cancellationToken);

            return listOfCategory;
        }

        public async Task<Category?> FindByIdAsync(Guid categoryId, CancellationToken cancellationToken)
        {
            var category = await _dbContext.Categories.AsTracking().FirstOrDefaultAsync(category => category.Id == categoryId, cancellationToken);

            return category;
        }

        public async Task<Category?> FindByTitleAsync(string categoryTitle, CancellationToken cancellationToken)
        {
            var category = await _dbContext.Categories.FirstOrDefaultAsync(category => category.Title == categoryTitle, cancellationToken);

            return category;
        }

        public async Task<RepositoryResult> UpdateAsync(Category category, JsonPatchDocument<Category> request, CancellationToken cancellationToken)
        {
            request.ApplyTo(category);

            await SaveChangesAsync(cancellationToken);

            return new RepositoryResult(true);
        }

        public async Task<RepositoryResult> DeleteAsync(Category category, CancellationToken cancellationToken)
        {
            await ResetCategory(category, cancellationToken);

            var deleteResult = _dbContext.Categories.Remove(category);

            if (deleteResult.State is not EntityState.Deleted)
            {
                return new RepositoryResult(false, new CategoryStateException(deleteResult.State.ToString()));
            }

            await SaveChangesAsync(cancellationToken);

            return new RepositoryResult(true);
        }

        private async Task ResetCategory(Category category, CancellationToken cancellationToken)
        {
            await _dbContext.Entry(category)
                .Collection(m => m.Products)
                .LoadAsync(cancellationToken);

            foreach (var product in category.Products)
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