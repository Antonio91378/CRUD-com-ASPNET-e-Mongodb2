using API.Blog.BackEnd.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Blog.BackEnd.Domain.Interfaces
{
    public interface ICommentRepo
    {
        Task<Guid?> CreateCommentAsync(Comment comment);
        Task<List<Comment>?> DisplayAllCommentAsync();
        Task<Comment> DisplayCommentByIdAsync(Guid id);
        Task<bool> DeleteCommentByIdAsync(Guid id);
    }
}
