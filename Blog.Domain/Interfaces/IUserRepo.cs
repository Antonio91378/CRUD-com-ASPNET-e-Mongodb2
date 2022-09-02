using API.Blog.BackEnd.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Blog.BackEnd.Domain.Interfaces
{
    public interface IUserRepo
    {

        Task CreateUserAsync(User user);
        Task<List<User>> DisplayAllUsersAsync();
        Task<User> DisplayUserByIdAsync(string id);
        Task UpdateUserByIdAsync(User user);
        Task DeleteUserByIdAsync(string id);
    }
}
