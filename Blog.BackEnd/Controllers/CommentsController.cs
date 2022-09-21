using API.Blog.BackEnd.Domain.Dto.Request;
using API.Blog.BackEnd.Domain.Entities;
using API.Blog.BackEnd.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Blog.BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController: ControllerBase
    {
        readonly ICommentRepo _commentRepo;

        public CommentsController(ICommentRepo commentRepo)
        {
            _commentRepo = commentRepo;
        }

        [HttpGet]
        [Route("/comments")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DisplayComments()
        {
            var comments = await _commentRepo.DisplayAllCommentAsync();
            if (comments.Count == 0)
            {
                var problemDetails = new ProblemDetails();
                problemDetails.Status = StatusCodes.Status404NotFound;
                problemDetails.Type = "NotFound";
                problemDetails.Title = "Posts not found";
                problemDetails.Detail = "It wasn't possible to find posts";
                problemDetails.Instance = HttpContext.Request.Path;
                return NotFound(problemDetails);
            }

            return Ok(comments);
        }
        [HttpGet]
        [Route("/comments/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DisplayComment(Guid id)
        {
            var comments = await _commentRepo.DisplayCommentByIdAsync(id);
            if (comments is null)
            {
                var problemDetails = new ProblemDetails();
                problemDetails.Status = StatusCodes.Status404NotFound;
                problemDetails.Type = "NotFound";
                problemDetails.Title = "Posts not found";
                problemDetails.Detail = "It wasn't possible to find posts";
                problemDetails.Instance = HttpContext.Request.Path;
                return NotFound(problemDetails);
            }

            return Ok(comments);
        }
        [HttpPost]
        [Route("/comments")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateComment([FromBody] CreateCommentDto comment)
        {
            if (comment != null)
            {
                var res = await _commentRepo.CreateCommentAsync(comment);
                return StatusCode((int)HttpStatusCode.Created, res);
            }
            else
            {
                var problemDetails = new ProblemDetails();
                problemDetails.Status = StatusCodes.Status400BadRequest;
                problemDetails.Type = "BadRequest";
                problemDetails.Title = "Post can't not be null";
                problemDetails.Detail = "It wasn't possible to create a post";
                problemDetails.Instance = HttpContext.Request.Path;
                return BadRequest(problemDetails);
            }
        }
    }
}
