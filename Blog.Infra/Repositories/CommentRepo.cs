using API.Blog.BackEnd.Domain.Dto.Request;
using API.Blog.BackEnd.Domain.Dto.Response;
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

        public async Task<List<ReadCommentDto>> DisplayAllCommentAsync()
        {
            List<Comment> comments = ContextEF.Comments.ToList();
            List<ReadCommentDto> readComments = _mapper.Map<List<ReadCommentDto>>(comments);
            return readComments;
        }

        public async Task<ReadCommentDto> DisplayCommentByIdAsync(Guid id)
        {
            Comment comment = ContextEF.Comments.FirstOrDefault(comment => comment.Id == id);
            if(comment is not null)
            {
                ReadCommentDto readComment = _mapper.Map<ReadCommentDto>(comment);
                return readComment;
            }
            throw new NotImplementedException();
        }
        
        

    }
}
