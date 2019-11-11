using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GameStore.BLL.DTO;
using GameStore.BLL.Interfaces;
using GameStore.PL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.PL.Controller
{
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;
        private IMapper _autoMapper;
        public CommentController(ICommentService commentService, IMapper autoMapper)
        {
            _commentService = commentService;
            _autoMapper = autoMapper;
        }

        [HttpGet]
        //[Route("api/games/{id}/comments")]
        [Route("api/comments/{id}")]
        public async Task<IActionResult> GetComments(int gameId)
        {
            //var comments = _autoMapper.Map<IEnumerable<CommentDto>, IEnumerable<CommentModel>>(await _commentService.GetAllComments(id));
            //return comments;

            return Ok(await _commentService.GetAllComments(gameId));

        }

        [HttpPost]
        [Route("api/games/{gameId}/comments")]
        public async Task<IActionResult> AddComment(int gameId, [FromBody]CommentDto commentDto)
        {
            //var comment = _commentService.AddComment(gameId, commentDto);
            //return Ok("Comment added");
            await _commentService.AddComment(gameId, commentDto);
            return Ok("Comment added");
        }

    }
}