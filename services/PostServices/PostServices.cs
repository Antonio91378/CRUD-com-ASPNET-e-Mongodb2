using BlogWithMongo_BackEnd.Models;
using BlogWithMongo_BackEnd.PostServices;
using Microsoft.Extensions.Options;
using MongoDB.Driver;


namespace PostsServices.PostServices
{
    public class PostServices
    {
        private readonly IMongoCollection<Post> _postCollection;

        public PostServices(IOptions<PostDatabaseSettings> postServices)
        {
            var mongoClient = new MongoClient(postServices.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(postServices.Value.DatabaseName);

            _postCollection = mongoDatabase.GetCollection<Post>(postServices.Value.PostCollectionName);
        }

        public async Task<List<Post>> GetAsync() =>
            await _postCollection.Find(x => true).ToListAsync();

        public async Task<Post> GetAsync(string id) =>
            await _postCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Post post) =>
            await _postCollection.InsertOneAsync(post);

        public async Task UpdateAsync(string id, Post post) =>
            await _postCollection.ReplaceOneAsync(x => x.Id == id, post);
        public async Task RemoveAsync(string id) =>
            await _postCollection.DeleteOneAsync(x => x.Id == id);
    }
}
