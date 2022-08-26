
using BlogWithMongo_BackEnd.Models;
using Microsoft.AspNetCore.Mvc;
using BlogWithMongo_BackEnd.UserServices;

namespace BlogWithMongo_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserService _userServices;

        public UsersController(UserService userServices)
        {
            _userServices = userServices;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _userServices.GetAsync();
        }

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
