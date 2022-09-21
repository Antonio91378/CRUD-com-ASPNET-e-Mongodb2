using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Blog.BackEnd.Domain.Dto.Request
{
    public class CreateRepliedCommentDto
    {
        [MaxLength(30, ErrorMessage = "O tamanho maximo para o campo Nome é de 30 caracteres.")]
        public string Autor { get; set; }
        public string Content { get; set; }

        [ForeignKey("Comment")]
        [Required]
        public Guid IdComment { get; set; }
    }
}
