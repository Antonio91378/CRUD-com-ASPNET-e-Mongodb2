
using Microsoft.AspNetCore.Mvc;

namespace API.Blog.BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        [HttpGet("Get String")]
        public string GetString()
        {
            return "OI";
        }
    }
}
