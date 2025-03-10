﻿using API.Blog.BackEnd.Domain.Dto.Request;
using API.Blog.BackEnd.Domain.Dto.Response;
using API.Blog.BackEnd.Domain.Entities;
using API.Blog.BackEnd.Domain.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Blog.BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepliedCommentsController : ControllerBase
    {
        readonly IRepliedCommentRepo _repliedCommentRepo;
        readonly IMapper _mapper;

        public RepliedCommentsController(IRepliedCommentRepo repliedCommentRepo, IMapper mapper)
        {
            _repliedCommentRepo = repliedCommentRepo;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("/repliedComments/{idComment}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DisplayComments(Guid idComment)
        {
            var repliedComments = await _repliedCommentRepo.DisplayAllCommentAsync(idComment);
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
            //var CommentDto = _mapper.Map<ReadCommentDto>(repliedComments);
            return Ok(repliedComments);
        }
        [HttpPost]
        [Route("/RepliedComments")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateComment([FromBody] CreateRepliedCommentDto repliedComment)
        {

            var res = await _repliedCommentRepo.CreateCommentAsync(repliedComment);
            if (res is not null)
            {
                return Ok(res);
            }
            else
            {
                ProblemDetails detalhesDoProblema = new ProblemDetails();
                detalhesDoProblema.Status = StatusCodes.Status404NotFound;
                detalhesDoProblema.Type = "NotFound";
                detalhesDoProblema.Title = "Registro não Encontrado";
                detalhesDoProblema.Detail = $"Não foram encontrados registros. ";
                detalhesDoProblema.Instance = HttpContext.Request.Path;
                return NotFound(detalhesDoProblema);
            }
        }
    }
}

