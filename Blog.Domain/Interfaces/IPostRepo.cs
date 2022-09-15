using API.Blog.BackEnd.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Blog.BackEnd.Domain.Interfaces
{
    public interface IPostRepo
    {

        Task CreatePostAsync(Post post);
        Task<List<Post>> DisplayAllPostsAsync();
        Task<Post> DisplayPostByIdAsync(string id);
        Task DeletePostByIdAsync(string id);
    }
}
