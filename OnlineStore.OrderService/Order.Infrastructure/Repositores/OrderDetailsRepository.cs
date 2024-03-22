using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Order.Domain.Entities;
using Order.Infrastructure.Abstractions.Interfaces;
using Order.Infrastructure.Options;

namespace Order.Infrastructure.Repositores
{
    public class OrderDetailsRepository : BaseRepository<OrderDetailsEntity>, IOrderDetailsRepository
    {
        public OrderDetailsRepository(
            IOptions<OrderStoreDatabaseSettings> orderStoreDatabaseSettings) :
            base(GetMongoCollection(orderStoreDatabaseSettings))
        {
        }

        private static IMongoCollection<OrderDetailsEntity> GetMongoCollection(IOptions<OrderStoreDatabaseSettings> settings)
        {
            var mongoClient = new MongoClient(settings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(settings.Value.DatabaseName);

            return mongoDatabase.GetCollection<OrderDetailsEntity>(settings.Value.OrderDetailsCollectionName);
        }        
    }
}