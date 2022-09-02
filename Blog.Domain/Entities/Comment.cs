using System.Data;

namespace API.Blog.BackEnd.Domain.Entities
{
    public class Comment
    {
        public string Autor { get; set; }
        public string Conteudo { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}