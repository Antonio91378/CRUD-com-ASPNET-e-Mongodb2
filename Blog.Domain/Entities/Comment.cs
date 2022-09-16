using System.ComponentModel.DataAnnotations;
using System.Data;

namespace API.Blog.BackEnd.Domain.Entities
{
    public class Comment
    {
        [Key]
        public Guid? Id { get; set; } 
        public string Autor { get; set; }
        public string Content { get; set; }
        public List<string> RepliedContents { get; set; }
        public DateTime CriationData { get; set; }
    }
}