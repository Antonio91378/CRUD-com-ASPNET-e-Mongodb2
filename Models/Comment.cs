using System.Data;

namespace BlogWithMongo_BackEnd.Models
{
    public class Comment
    {
        public string Autor { get; set; }
        public string Conteudo { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}