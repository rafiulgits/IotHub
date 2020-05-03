using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace IotHub.DomainModels.Base
{
    public class BaseEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = ObjectId.GenerateNewId().ToString();
    }
}
