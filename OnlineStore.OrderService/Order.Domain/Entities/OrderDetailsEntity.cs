using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Order.Domain.Entities
{
    [BsonIgnoreExtraElements]
    public class OrderDetailsEntity : IHasId
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("FirstName")]
        public string FirstName { get; set; }

        [BsonElement("LastName")]
        public string LastName { get; set; }

        [BsonElement("Email")]
        public string Email { get; set; }

        [BsonElement("Address")]
        public string Address { get; set; }

        [BsonElement("Town")]
        public string Town { get; set; }

        [BsonElement("Comment")]
        public string Comment { get; set; }

        [BsonElement("IdOrderProducts")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? IdOrderProducts { get; set; }
    }
}