using API.Blog.BackEnd.Domain.Dto.Request;
using API.Blog.BackEnd.Domain.Entities;


namespace API.Blog.BackEnd.Domain.Interfaces
{
    public interface IRepliedCommentRepo
    {
        Task<IEnumerable<RepliedComment>> CreateCommentAsync(CreateRepliedCommentDto repliedComment);
        Task<IEnumerable<RepliedComment>> DisplayAllCommentAsync(Guid id);
        Task<bool> DeleteCommentByIdAsync(Guid id);
    }
}
