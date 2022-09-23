using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API.Blog.BackEnd.Domain.Entities
{
    public class RepliedComment
    {
        [Key]
        [Required]
        [Column("IdRepliedComment")]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "O Autor do comentario é obrigatório.")]
        [MaxLength(30, ErrorMessage = "O tamanho maximo para o campo Nome é de 30 caracteres.")]
        public string Autor { get; set; }
        [Required(ErrorMessage = "O comentario é obrigatório.")]
        [MaxLength(30, ErrorMessage = "O tamanho maximo para o campo Nome é de 30 caracteres.")]
        public string Content { get; set; }
        [ForeignKey("Comment")]
        [Required]
        public Guid IdComment { get; set; }
        public virtual Comment CurrentComment { get; set; }
        public DateTime CriationData { get; set; }
    }
}
