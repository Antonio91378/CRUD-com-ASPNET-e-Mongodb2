using API.Blog.BackEnd.Domain.Entities;
using API.Blog.BackEnd.Domain.Interfaces;
using MongoDB.Driver;
using Blog.Utils;

namespace API.Blog.BackEnd.Infra.Contexts
{
    internal class Context : IContext
    {

        public IMongoCollection<User> User { get; }
        public IMongoCollection<Post> Post { get; }

        public Context()
        {
            var client = new MongoClient(ApplicationSettings.GetMongoDBConnectionString());
            var DataBase = client.GetDatabase("Blog");
            User = DataBase.GetCollection<User>("Users");
            Post = DataBase.GetCollection<Post>("Posts");

        }
    }
}
