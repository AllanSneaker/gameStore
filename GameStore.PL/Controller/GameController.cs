using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameStore.BLL.DTO;
using GameStore.BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.PL.Controller
{
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpGet]
        [Route("api/games")]
        public async Task<IActionResult> GetAllGames()
        {
            return Ok(await _gameService.GetAllGames());
        }

        [HttpGet]
        [Route("api/game/{id}")]
        public async Task<IActionResult> GetGame(int id)
        {
            return Ok(await _gameService.Get(id));
        }

        [HttpPost]
        [Route("api/game")]
        public async Task<IActionResult> PostGame([FromBody]GameDto gameDto)
        {
            return Ok(await _gameService.Create(gameDto));
        }
    }
}