using API.Blog.BackEnd.Domain.Entities;
using API.Blog.BackEnd.Domain.Interfaces;
using API.Blog.BackEnd.Infra.Contexts;
using MongoDB.Driver;

namespace Blog.Infra.Repositories
{
    public class PostRepo : IPostRepo
    {
        private readonly IContext _context;

        public PostRepo()
        {
            _context = new Context();
        }

        public async Task CreatePostAsync(Post Post)
        {
            await _context.Posts.InsertOneAsync(Post);
        }

        public async Task<List<Post>> DisplayAllPostsAsync()
        {
            var Posts = await _context.Posts.FindAsync(_ => true);
            return Posts.ToList();
        }

        public async Task<Post> DisplayPostByIdAsync(string id)
        {
            var Post = await _context.Posts.Find(_ => _.Id == id).FirstOrDefaultAsync();
            return Post;
        }

        public async Task DeletePostByIdAsync(string id)
        {
            await _context.Posts.DeleteOneAsync(_ => _.Id == id);
        }
    }
}
