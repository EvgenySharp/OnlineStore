using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Order.Domain.Entities
{

    [BsonIgnoreExtraElements]
    public class OrderEntity : IHasId
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("IdOrderDetails")]
        public string? IdOrderDetails { get; set; }
    }
}