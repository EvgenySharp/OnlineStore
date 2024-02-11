using Catalog.Domain.Entities;

namespace Catalog.Persistence.Abstractions.Interfaces
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
        Task<Category?> FindByTitleAsync(string categoryTitle, CancellationToken cancellationToken);
        Task<RepositoryResult> ChangeTitleAsync(Category category, string mewTitle, CancellationToken cancellationToken);
    }
}