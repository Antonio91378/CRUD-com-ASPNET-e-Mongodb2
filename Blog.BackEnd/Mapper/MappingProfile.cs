using API.Blog.BackEnd.Domain.Entities;
using AutoMapper;
using Blog.Domain.Dto.Response;

namespace API.Blog.BackEnd.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserResponseDto>();
        }
    }
}