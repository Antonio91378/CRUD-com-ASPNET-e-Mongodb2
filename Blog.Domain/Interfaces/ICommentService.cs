using API.Blog.BackEnd.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Blog.BackEnd.Domain.Interfaces
{
    public interface ICommentService
    {
        Task<Guid?> CreateCommentAsync(Comment comment);
        Task<List<Comment>> DisplayAllCommentAsync();
        Task<Comment> DisplayCommentByIdAsync(Guid id);
        Task DeleteCommentByIdAsync(Guid id);
    }
}
