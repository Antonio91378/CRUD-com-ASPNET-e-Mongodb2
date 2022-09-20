using API.Blog.BackEnd.Domain.Entities;
using API.Blog.BackEnd.Domain.Interfaces;
using API.Blog.BackEnd.Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace API.Blog.BackEnd.Domain.Interfaces
{
    public class RepliedCommentRepo : IRepliedCommentRepo
    {
        private readonly Context2 ContextEF;
        public RepliedCommentRepo()
        {
            ContextEF = new Context2();
        }

        public async Task<List<RepliedComment>> CreateCommentAsync(RepliedComment comment)
        {
            var validComment = await ContextEF.Comments.FindAsync(comment.IdComment);
            if(validComment == null)
            {
                throw new Exception("comentario nao encontrado");
            }
            var newRepliedComment = new RepliedComment
            {
                Id = comment.Id,
                Autor = comment.Autor,
                Content = comment.Content,
                IdComment = comment.IdComment,
                CurrentComment = validComment,
                CriationData = comment.CriationData,
            };

            ContextEF.RepliedComments.Add(newRepliedComment);
            ContextEF.SaveChangesAsync();
            var comments = await DisplayAllCommentAsync(newRepliedComment.IdComment);
            return comments;
        }
        public async Task<List<RepliedComment>> DisplayAllCommentAsync(Guid id)
        {
           var rComments = ContextEF.RepliedComments.Where(x => x.IdComment == id).ToList();
            return rComments;
        } 
        public async Task<bool> DeleteCommentByIdAsync(Guid id)
        {
            var selectedComment = ContextEF.Set<RepliedComment>().Where(x => x.Id == id).FirstOrDefault();
            if (selectedComment == null)
                return false;
            ContextEF.RepliedComments.Remove(selectedComment);
            ContextEF.SaveChanges();
            return true;
        }
    }
}
