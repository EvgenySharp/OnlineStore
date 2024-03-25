using MongoDB.Driver;
using Order.Domain;
using Order.Infrastructure.Abstractions.Interfaces;

namespace Order.Infrastructure.Repositores
{
    public abstract class BaseRepository<T> :  IBaseRepository<T> where T : class, IHasId
    {
        protected readonly IMongoCollection<T> _mongoCollection;

        protected BaseRepository(IMongoCollection<T> mongoCollection)
        {
            _mongoCollection = mongoCollection;
        }

        public virtual async Task<Task> CreateAsync(T entity, CancellationToken cancellationToken)
        {
            var task = _mongoCollection.InsertOneAsync(entity, cancellationToken);
            await task;

            return task;
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _mongoCollection.Find(_ => true).ToListAsync(cancellationToken);
        }

        public virtual async Task<T?> FindByIdAsync(string id, CancellationToken cancellationToken)
        {
            return await _mongoCollection.Find(x => x.Id == id).FirstOrDefaultAsync(cancellationToken);
        }

        public virtual async Task<DeleteResult> DeleteAsync(string id, CancellationToken cancellationToken)
        {
            var deleteResult = await _mongoCollection.DeleteOneAsync(x => x.Id == id, cancellationToken);

            return deleteResult;
        }
    }
}