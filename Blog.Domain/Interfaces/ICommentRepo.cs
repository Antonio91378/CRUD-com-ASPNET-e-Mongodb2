using API.Blog.BackEnd.Domain.Dto.Request;
using API.Blog.BackEnd.Domain.Dto.Response;
using API.Blog.BackEnd.Domain.Entities;

namespace API.Blog.BackEnd.Domain.Interfaces
{
    public interface ICommentRepo
    {
        Task<Comment> CreateCommentAsync(CreateCommentDto comment);
        Task<List<ReadCommentDto>> DisplayAllCommentAsync();
        Task<ReadCommentDto> DisplayCommentByIdAsync(Guid id);
        Task<bool> DeleteCommentByIdAsync(Guid id);
    }
}
