

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BlogWithMongo_BackEnd.Models
{
    public class User
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("email")]
        [BsonRepresentation(BsonType.String)]
        public string Email { get; set; }

        [BsonElement("password")]
        [BsonRepresentation(BsonType.String)]

        public string PassWord { get; set; }
    }
}