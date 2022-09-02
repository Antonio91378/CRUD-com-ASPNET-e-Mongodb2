using API.Blog.BackEnd.Domain.Entities;
using API.Blog.BackEnd.Domain.Interfaces;
using MongoDB.Driver;

namespace Blog.Infra.Repositories
{
    public class PostRepo
    {
        private readonly IContext _context;

        public PostRepo(IContext context)
        {
            _context = context;
        }

        public async Task CreatePostAsync(Post Post)
        {
            await _context.Post.InsertOneAsync(Post);
        }

        public async Task<List<Post>> DisplayAllPostsAsync()
        {
            var Posts = await _context.Post.FindAsync(_ => true);
            return Posts.ToList();
        }

        public async Task<Post> DisplayPostByIdAsync(string id)
        {
            var Post = await _context.Post.Find(_ => _.Id == id).FirstOrDefaultAsync();
            return Post;
        }

        public async Task UpdatePostByIdAsync(Post Post)
        {
            await _context.Post.ReplaceOneAsync(_ => _.Id == Post.Id, Post, new UpdateOptions { IsUpsert = true });
        }
        public async Task DeletePostByIdAsync(string id)
        {
            await _context.Post.DeleteOneAsync(_ => _.Id == id);
        }
    }
}
