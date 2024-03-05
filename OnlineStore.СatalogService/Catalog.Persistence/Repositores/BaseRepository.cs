using Catalog.Persistence.Abstractions.Interfaces;
using Catalog.Persistence.Exceptions;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Persistence.Repositores
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly DbContext _dbContext;

        public BaseRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task<RepositoryResult> CreateAsync(T entity, CancellationToken cancellationToken)
        {
            var addResult = await _dbContext.Set<T>().AddAsync(entity, cancellationToken);

            if (addResult.State is not EntityState.Added)
            {
                return new RepositoryResult(false, new ProductStateException(addResult.State.ToString()));
            }

            await SaveChangesAsync(cancellationToken);

            return new RepositoryResult(true);
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _dbContext.Set<T>().ToListAsync(cancellationToken);
        }

        public virtual async Task<T?> FindByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var product = await _dbContext.Set<T>().FindAsync(new object[] { id }, cancellationToken);

            return product;
        }

        public virtual async Task<RepositoryResult> UpdateAsync(T entity, JsonPatchDocument<T> request, CancellationToken cancellationToken)
        {
            request.ApplyTo(entity);

            await SaveChangesAsync(cancellationToken);

            return new RepositoryResult(true);
        }

        public virtual async Task<RepositoryResult> DeleteAsync(T entity, CancellationToken cancellationToken)
        {
            var deleteResult = _dbContext.Set<T>().Remove(entity);

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