using System.ComponentModel.DataAnnotations;
using System.Data;

namespace API.Blog.BackEnd.Domain.Entities
{
    public class Comment
    {
        [Key]
        public Guid? Id { get; set; } 
        public string Autor { get; set; }
        public string Conteudo { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}