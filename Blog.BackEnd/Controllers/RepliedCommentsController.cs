using API.Blog.BackEnd.Domain.Entities;
using API.Blog.BackEnd.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Blog.BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepliedCommentsController : ControllerBase
    {
        readonly IRepliedCommentRepo _repliedCommentRepo;

        public RepliedCommentsController(IRepliedCommentRepo repliedCommentRepo)
        {
            _repliedCommentRepo = repliedCommentRepo;
        }

        [HttpGet]
        [Route("/repliedComments")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DisplayComments()
        {
            var repliedComment = await _repliedCommentRepo.DisplayAllCommentAsync();
            if (repliedComment.Count == 0)
            {
                var problemDetails = new ProblemDetails();
                problemDetails.Status = StatusCodes.Status404NotFound;
                problemDetails.Type = "NotFound";
                problemDetails.Title = "Posts not found";
                problemDetails.Detail = "It wasn't possible to find posts";
                problemDetails.Instance = HttpContext.Request.Path;
                return NotFound(problemDetails);
            }

            return Ok(repliedComment);
        }

        [HttpGet]
        [Route("/repliedComments/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DisplayComment(Guid id)
        {
            var repliedComments = await _repliedCommentRepo.DisplayCommentByIdAsync(id);
            if (repliedComments is null)
            {
                var problemDetails = new ProblemDetails();
                problemDetails.Status = StatusCodes.Status404NotFound;
                problemDetails.Type = "NotFound";
                problemDetails.Title = "Posts not found";
                problemDetails.Detail = "It wasn't possible to find posts";
                problemDetails.Instance = HttpContext.Request.Path;
                return NotFound(problemDetails);
            }

            return Ok(repliedComments);
        }
        [HttpPost]
        [Route("/RepliedComments")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateComment([FromBody] RepliedComment repliedComment)
        {
            if (repliedComment != null)
            {
                await _repliedCommentRepo.CreateCommentAsync(repliedComment);
                return StatusCode((int)HttpStatusCode.Created, repliedComment );
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

