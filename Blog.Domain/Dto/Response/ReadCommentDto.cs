using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Blog.BackEnd.Domain.Dto.Response
{
    public class ReadCommentDto
    {
        public string Autor { get; set; }
        public string CurrentComment { get; set; }
    }
}
