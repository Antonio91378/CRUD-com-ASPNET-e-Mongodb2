using API.Blog.BackEnd.Domain.Dto.Request;
using API.Blog.BackEnd.Domain.Dto.Response;
using API.Blog.BackEnd.Domain.Entities;


namespace API.Blog.BackEnd.Domain.Interfaces
{
    public interface IRepliedCommentRepo
    {
        Task<List<ReadRepliedCommentDto>> CreateCommentAsync(CreateRepliedCommentDto repliedComment);
        Task<List<ReadRepliedCommentDto>> DisplayAllCommentAsync(Guid id);
        Task<bool> DeleteCommentByIdAsync(Guid id);
    }
}
