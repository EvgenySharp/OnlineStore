using Order.Domain.Entities;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Order.Infrastructure.Abstractions.Interfaces;
using Order.Infrastructure.Options;

namespace Order.Infrastructure.Repositores
{
    public class OrderProductsRepository : BaseRepository<OrderProductsEntity>, IOrderProductsRepository
    {
        public OrderProductsRepository(
            IOptions<OrderStoreDatabaseSettings> orderStoreDatabaseSettings) :
            base(GetMongoCollection(orderStoreDatabaseSettings))
        {
        }

        private static IMongoCollection<OrderProductsEntity> GetMongoCollection(IOptions<OrderStoreDatabaseSettings> settings)
        {
            var mongoClient = new MongoClient(settings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(settings.Value.DatabaseName);

            return mongoDatabase.GetCollection<OrderProductsEntity>(settings.Value.OrderProductsCollectionName);
        }
    }
}