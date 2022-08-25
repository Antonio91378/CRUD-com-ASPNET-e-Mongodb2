
//using Microsoft.AspNetCore.Mvc;


//namespace BlogWithMongo_BackEnd.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class PostsController : ControllerBase
//    {
//        private readonly PostServices _postServices;

//        public PostsController(PostServices postServices)
//        {
//            _postServices = postServices;
//        }

//        [HttpGet]
//        public async Task<List<Post>> GetPosts()
//            => await _postServices.GetAsync();

//        [HttpPost]
//        public async Task<Post> PostPost(Post post)
//        {
//            await _postServices.CreateAsync(post);
//            return post;
//        }

//        [HttpPatch]
//        public async Task UpdatePost(string id, Post post)
//        {
//            await _postServices.UpdateAsync(id, post);
//        }
//    }
//}
