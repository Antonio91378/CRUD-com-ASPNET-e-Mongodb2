
using API.Blog.BackEnd.Domain.Entities;
using Blog.Domain.Dto.Response;

namespace Blog.Domain.Interfaces
{
    public interface IUserService
    {
        Task CreateUserAsync(User user);
        Task<List<User>> DisplayAllUsersAsync();
        Task<UserResponseDto> DisplayUserByIdAsync(string id);
        Task UpdateUserByIdAsync(User user);
        Task DeleteUserByIdAsync(string id);
    }
}