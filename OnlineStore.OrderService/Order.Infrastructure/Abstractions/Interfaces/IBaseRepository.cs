using MongoDB.Driver;

namespace Order.Infrastructure.Abstractions.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        Task<Task> CreateAsync(T entity, CancellationToken cancellationToken);
        Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken);
        Task<T?> FindByIdAsync(string id, CancellationToken cancellationToken);
        Task<DeleteResult> DeleteAsync(string id, CancellationToken cancellationToken);
    }
}