using API.Blog.BackEnd.Domain.Entities;


namespace API.Blog.BackEnd.Domain.Dto.Response
{
    public class ReadRepliedCommentDto
    {
        public string Autor { get; set; }
        public Comment CurrentComment { get; set; }
        public string Content { get; set; }
        public DateTime CriationData { get; set; }
    }
}
