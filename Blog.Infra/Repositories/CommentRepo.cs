using API.Blog.BackEnd.Domain.Dto.Request;
using API.Blog.BackEnd.Domain.Dto.Response;
using API.Blog.BackEnd.Domain.Entities;
using API.Blog.BackEnd.Domain.Interfaces;
using API.Blog.BackEnd.Infra.Contexts;
using API.Blog.BackEnd.Infra.Integrations;
using AutoMapper;

namespace API.Blog.BackEnd.Infra.Repositories
{
    public class CommentRepo : ICommentRepo
    {
        private readonly IIntegrationApiImageUploader _imageUploader;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly Context2 ContextEF;
        private readonly IMapper _mapper;
        public CommentRepo(IMapper mapper, IHttpClientFactory httpClientFactory)
        {
            _mapper = mapper;
            ContextEF = new Context2();
            _httpClientFactory = httpClientFactory;
            _imageUploader = new IntegrationApiImageUploader(_httpClientFactory);
        }

    
        public async Task<Comment> CreateCommentAsync(CreateCommentDto currentComment)
        {
            var solicitandoUpload = "";
            solicitandoUpload = await _imageUploader.FazerUpload(currentComment.ImageContent);
            Comment comment = _mapper.Map<Comment>(currentComment);
            comment.ImageContent = solicitandoUpload;
            ContextEF.Comments.AddAsync(comment);
            ContextEF.SaveChangesAsync();
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
