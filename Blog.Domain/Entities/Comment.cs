using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Text.Json.Serialization;

namespace API.Blog.BackEnd.Domain.Entities
{
    public class Comment
    {
        [Key]
        [Column("IdComment")]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "O autor do comentario � obrigat�rio.")]
        [MaxLength(50, ErrorMessage = "O tamanho maximo para o campo Nome � de 30 caracteres.")]
        public string Autor { get; set; }
        [Required(ErrorMessage = "O comentario � obrigat�rio.")]
        [MaxLength(200, ErrorMessage = "O tamanho maximo para o campo Nome � de 30 caracteres.")]
        public string CurrentComment { get; set; }
        [JsonIgnore]
        public virtual List<RepliedComment> RepliedComments { get; set; }
        public DateTime CriationData { get; set; }
    }
}