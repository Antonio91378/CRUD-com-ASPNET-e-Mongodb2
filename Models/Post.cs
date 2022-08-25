using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BlogWithMongo_BackEnd.Models
{
    public class Post
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Autor { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public List<string> Tags { get; set; }
        public List<Comment> Comments { get; set; }
    }
}