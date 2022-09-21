using API.Blog.BackEnd.Domain.Dto.Request;
using API.Blog.BackEnd.Domain.Entities;
using API.Blog.BackEnd.Domain.Interfaces;
using API.Blog.BackEnd.Infra.Contexts;
using AutoMapper;

namespace API.Blog.BackEnd.Infra.Repositories
{
    public class CommentRepo : ICommentRepo
    {
        private readonly Context2 ContextEF;
        private readonly IMapper _mapper;
        public CommentRepo(IMapper mapper)
        {
            _mapper = mapper;
            ContextEF = new Context2();
        }

    
        public async Task<Comment> CreateCommentAsync(CreateCommentDto currentComment)
        {
            Comment comment = _mapper.Map<Comment>(currentComment);
            ContextEF.Comments.AddAsync(comment);
            ContextEF.SaveChangesAsync();
            //var commentCreated = await DisplayCommentByIdAsync(comment.Id);
            return comment;
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

        public async Task<List<Comment>> DisplayAllCommentAsync() => ContextEF.Comments.ToList();

        public async Task<Comment> DisplayCommentByIdAsync(Guid id)
        {

            var foundComment = ContextEF.Comments.FirstOrDefault(x => x.Id == id);
            return foundComment;

        }
        
        

    }
}
