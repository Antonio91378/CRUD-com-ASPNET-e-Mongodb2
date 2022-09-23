
using API.Blog.BackEnd.Domain.Entities;

namespace Blog.Domain.Interfaces
{
    public interface IPostService
    {
        Task CreatePostAsync(Post post);
        Task<List<Post>> DisplayAllPostsAsync();
        Task<Post> DisplayPostByIdAsync(string id);
        Task DeletePostByIdAsync(string id);
    }
}