using Catalog.Domain.Entities;

namespace Catalog.Persistence.Abstractions.Interfaces
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
        Task<IEnumerable<Category>> GetPageAsync(int pageSize, int pageNumber, CancellationToken cancellationToken);
        Task<Category?> FindByTitleAsync(string categoryTitle, CancellationToken cancellationToken);
    }
}