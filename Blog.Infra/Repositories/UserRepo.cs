using API.Blog.BackEnd.Domain.Entities;
using API.Blog.BackEnd.Domain.Interfaces;
using MongoDB.Driver;

namespace API.Blog.BackEnd.Infra.Repositories
{
    public class UserRepo : IUserRepo
    {
        private readonly IContext _context;

        public UserRepo(IContext context)
        {
            _context = context;
        }

        public async Task CreateUserAsync(User user)
        {
            await _context.User.InsertOneAsync(user);
        }

        public async Task<List<User>> DisplayAllUsersAsync()
        {
            var users = await _context.User.FindAsync(_ => true);
            return users.ToList();
        }

        public async Task<User> DisplayUserByIdAsync(string id)
        {
            var user = await _context.User.Find(_ => _.Id == id).FirstOrDefaultAsync();
            return user;
        }

        public async Task UpdateUserByIdAsync(User user)
        {
            await _context.User.ReplaceOneAsync(_ => _.Id == user.Id, user, new UpdateOptions { IsUpsert = true });
        }
        public async Task DeleteUserByIdAsync(string id)
        {
            await _context.User.DeleteOneAsync(_ => _.Id == id);
        }
    }
}
