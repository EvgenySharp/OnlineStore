using Microsoft.AspNetCore.JsonPatch;
using MongoDB.Driver;
using Order.Domain;
using Order.Infrastructure.Abstractions.Interfaces;
using Order.Infrastructure.Exceptions;

namespace Order.Infrastructure.Repositores
{
    public abstract class BaseRepository<T> :  IBaseRepository<T> where T : class, IHasId
    {
        protected readonly IMongoCollection<T> _mongoCollection;

        protected BaseRepository(IMongoCollection<T> mongoCollection)
        {
            _mongoCollection = mongoCollection;
        }

        public virtual async Task<RepositoryResult> CreateAsync(T entity, CancellationToken cancellationToken)
        {
            var completedTask = _mongoCollection.InsertOneAsync(entity, cancellationToken);
            await completedTask;

            if (!completedTask.IsCompletedSuccessfully)
            {
                return new RepositoryResult(false, new TaskCompletedExceptions(completedTask.Status.ToString()));
            }

            return new RepositoryResult(true);
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _mongoCollection.Find(_ => true).ToListAsync();
        }

        public virtual async Task<T?> FindByIdAsync(string id, CancellationToken cancellationToken)
        {
            return await _mongoCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public virtual async Task<RepositoryResult> UpdateAsync(T entity, JsonPatchDocument<T> request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<RepositoryResult> DeleteAsync(string id, CancellationToken cancellationToken)
        {
            var deleteResult = await _mongoCollection.DeleteOneAsync(x => x.Id == id, cancellationToken);

            if (deleteResult.DeletedCount is 0)
            {
                return new RepositoryResult(false, new TaskCompletedExceptions("Not Found"));
            }

            return new RepositoryResult(true);
        }
    }
}