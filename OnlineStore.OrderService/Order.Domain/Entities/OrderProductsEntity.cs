using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Order.Domain.Entities
{
    [BsonIgnoreExtraElements]
    public class OrderProductsEntity : IHasId
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("ProductIds")]
        public List<string> ProductIds { get; set; }
    }
}
