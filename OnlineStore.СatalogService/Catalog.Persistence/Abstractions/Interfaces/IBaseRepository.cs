namespace Catalog.Persistence.Abstractions.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<RepositoryResult> CreateAsync(T entity, CancellationToken cancellationToken);
        Task<IEnumerable<T>> GetAllAsync(int pageSize, int pageNumber, CancellationToken cancellationToken);
        Task<T?> FindByIdAsync(Guid Id, CancellationToken cancellationToken);
        Task<RepositoryResult> DeleteAsync(T entity, CancellationToken cancellationToken);
    }
}