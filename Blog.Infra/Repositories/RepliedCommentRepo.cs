using API.Blog.BackEnd.Domain.Dto.Request;
using API.Blog.BackEnd.Domain.Entities;
using API.Blog.BackEnd.Domain.Interfaces;
using API.Blog.BackEnd.Infra.Contexts;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.Blog.BackEnd.Domain.Interfaces
{
    public class RepliedCommentRepo : IRepliedCommentRepo
    {
        private readonly Context2 ContextEF;
        private readonly IMapper _mapper;
        public RepliedCommentRepo(IMapper mapper)
        {
            _mapper = mapper;
            ContextEF = new Context2();
        }

        public async Task<IEnumerable<RepliedComment>> CreateCommentAsync(CreateRepliedCommentDto repliedComment)
        {
            RepliedComment comment = _mapper.Map<RepliedComment>(repliedComment);
            ContextEF.RepliedComments.Add(comment);
            ContextEF.SaveChangesAsync();
            var filteredComments = await DisplayAllCommentAsync(comment.IdComment);
            return filteredComments;
        }
        public async Task<IEnumerable<RepliedComment>> DisplayAllCommentAsync(Guid id)
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
