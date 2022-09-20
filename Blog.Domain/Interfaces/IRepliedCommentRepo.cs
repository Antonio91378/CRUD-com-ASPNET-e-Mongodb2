using API.Blog.BackEnd.Domain.Entities;


namespace API.Blog.BackEnd.Domain.Interfaces
{
    public interface IRepliedCommentRepo
    {
        Task<List<RepliedComment>> CreateCommentAsync(RepliedComment comment);
        Task<List<RepliedComment>> DisplayAllCommentAsync(Guid id);
        Task<bool> DeleteCommentByIdAsync(Guid id);
    }
}
