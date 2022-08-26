
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using BlogWithMongo_BackEnd.Models;

namespace BlogWithMongo_BackEnd.UserServices
{
    public class UserService
    {
        private readonly IMongoCollection<User> _userCollection;

        public UserService(IOptions<UserDatabaseSettings> userServices)
        {
            var mongoClient = new MongoClient(userServices.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(userServices.Value.DatabaseName);

            _userCollection = mongoDatabase.GetCollection<User>(userServices.Value.UserCollectionName);
        }

        public async Task<List<User>> GetAsync() =>
            await _userCollection.Find(x => true).ToListAsync();

        public async Task<User> GetAsync(string id) =>
            await _userCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(User user) =>
            await _userCollection.InsertOneAsync(user);

        public async Task UpdateAsync(string id, User user) =>
            await _userCollection.ReplaceOneAsync(x => x.Id == id, user);
        public async Task RemoveAsync(string id) =>
            await _userCollection.DeleteOneAsync(x => x.Id == id);
    }
}
