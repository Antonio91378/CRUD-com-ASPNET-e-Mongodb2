using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Blog.BackEnd.Domain.Dto.Request
{
    public class CreateCommentDto
    {
        public string Autor { get; set; }
        [MaxLength(30, ErrorMessage = "O tamanho maximo para o campo Nome é de 30 caracteres.")]
        public string CurrentComment { get; set; }
    }
}
