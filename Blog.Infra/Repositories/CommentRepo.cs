using API.Blog.BackEnd.Domain.Entities;
using API.Blog.BackEnd.Domain.Interfaces;
using API.Blog.BackEnd.Infra.Contexts;


namespace API.Blog.BackEnd.Infra.Repositories
{
    public class CommentRepo : ICommentRepo
    {
        private Context2 ContextEF { get; }
        public CommentRepo()
        {
            this.ContextEF = new Context2();
        }

    
        public async Task<Guid?> CreateCommentAsync(Comment comment)
        {
            await ContextEF.Comments.AddAsync(comment);
            ContextEF.SaveChanges();

            return comment.Id;
        }

        public async Task<bool> DeleteCommentByIdAsync(Guid id)
        {
            var selectedComment = ContextEF.Set<Comment>().Where(x => x.Id == id).FirstOrDefault();
            if (selectedComment == null)
                return false;
            ContextEF.Comments.Remove(selectedComment);
            ContextEF.SaveChanges();
            return true;
        }

        public async Task<List<Comment?>> DisplayAllCommentAsync() => ContextEF.Comments.ToList();

        public async Task<Comment?> DisplayCommentByIdAsync(Guid id) => ContextEF.Set<Comment>().Where(x => x.Id == id).FirstOrDefault();
        

    }
}
