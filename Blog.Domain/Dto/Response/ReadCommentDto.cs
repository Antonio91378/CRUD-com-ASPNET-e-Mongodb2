using API.Blog.BackEnd.Domain.Entities;
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
        public List<RepliedComment> RepliedComments { get; set; }
        public DateTime CriationData { get; set; }
    }
}
