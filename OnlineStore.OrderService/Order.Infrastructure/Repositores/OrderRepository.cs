using Order.Domain.Entities;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Order.Infrastructure.Abstractions.Interfaces;
using Order.Infrastructure.Options;

namespace Order.Infrastructure.Repositores
{
    public class OrderRepository : BaseRepository<OrderEntity>, IOrderRepository
    {
        public OrderRepository(
            IOptions<OrderStoreDatabaseSettings> orderStoreDatabaseSettings) : 
            base(GetMongoCollection(orderStoreDatabaseSettings))
        {
        }

        private static IMongoCollection<OrderEntity> GetMongoCollection(IOptions<OrderStoreDatabaseSettings> settings)
        {
            var mongoClient = new MongoClient(settings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(settings.Value.DatabaseName);

            return mongoDatabase.GetCollection<OrderEntity>(settings.Value.OrderCollectionName);
        }

        public async Task<IEnumerable<OrderEntity>> GetPageAsync(int pageSize, int pageCount, CancellationToken cancellationToken)
        {
            var filter = Builders<OrderEntity>.Filter.Empty;

            var orders = await _mongoCollection
                .Find(filter)
                .SortBy(o => o.Id)
                .Skip((pageCount - 1) * pageSize)
                .Limit(pageSize)
                .ToListAsync(cancellationToken);

            return orders;
        }
    }
}