
using BlogWithMongo_BackEnd.Models;
using Microsoft.AspNetCore.Mvc;
using BlogWithMongo_BackEnd.UsersService;
namespace BlogWithMongo_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly Pateta _userServices;

        public UsersController(Pateta userServices)
        {
            _userServices = userServices;
        }

        [HttpGet]
        public async Task<List<User>> GetUsers()
            => await _userServices.GetAsync();

        [HttpPost]
        public async Task<User> UserUser(User user)
        {
            await _userServices.CreateAsync(user);
            return user;
        }

        [HttpPatch]
        public async Task UpdateUser(string id, User user)
        {
            await _userServices.UpdateAsync(id, user);
        }
    }
}
