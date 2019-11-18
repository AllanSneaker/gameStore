using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using GameStore.BLL.DTO;
using GameStore.BLL.Interfaces;
using GameStore.PL.Models;
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
        [Route("api/games/{gameId}/comments")]
        public async Task<IEnumerable<CommentModel>> GetComments(int gameId)
        {
            var comments = _autoMapper.Map<IEnumerable <CommentModel>>(await _commentService.GetAllCommentsAsync(gameId));
            return comments;
        }

        [HttpPost]
        [Route("api/games/{gameId}/comments")]
        public async Task<IActionResult> AddComment(int gameId, [FromBody]AddCommentModel model)
        {
            var comment = _autoMapper.Map<AddCommentModel, CommentDto>(model);
            await _commentService.AddCommentAsync(gameId, comment);
            return Ok("Comment added");
        }
    }
}