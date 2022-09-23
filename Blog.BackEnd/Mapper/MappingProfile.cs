using API.Blog.BackEnd.Domain.Dto.Request;
using API.Blog.BackEnd.Domain.Dto.Response;
using API.Blog.BackEnd.Domain.Entities;
using AutoMapper;

namespace API.Blog.BackEnd.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateCommentDto,Comment>();
            CreateMap<CreateRepliedCommentDto, RepliedComment>();

            CreateMap<Comment, ReadCommentDto>();
            CreateMap<RepliedComment, ReadRepliedCommentDto>();
        }

    }
}
