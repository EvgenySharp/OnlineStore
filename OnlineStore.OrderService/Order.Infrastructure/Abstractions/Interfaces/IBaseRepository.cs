using Microsoft.AspNetCore.JsonPatch;

namespace Order.Infrastructure.Abstractions.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        Task<RepositoryResult> CreateAsync(T entity, CancellationToken cancellationToken);
        Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken);
        Task<T?> FindByIdAsync(string id, CancellationToken cancellationToken);
        Task<RepositoryResult> UpdateAsync(T entity, JsonPatchDocument<T> request, CancellationToken cancellationToken);
        Task<RepositoryResult> DeleteAsync(string id, CancellationToken cancellationToken);
    }
}