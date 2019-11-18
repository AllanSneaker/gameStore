using System.Threading.Tasks;
using GameStore.BLL.DTO;
using GameStore.BLL.Interfaces;
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
            return Ok(await _gameService.GetAllGamesAsync());
        }

        [HttpGet]
        [Route("api/game/{id}")]
        public async Task<IActionResult> GetGame(int id)
        {
            return Ok(await _gameService.GetAsync(id));
        }

        [HttpPost]
        [Route("api/game")]
        public async Task<IActionResult> PostGame([FromBody]GameDto gameDto)
        {
            return Ok(await _gameService.CreateAsync(gameDto));
        }

        [HttpPut]
        [Route("api/game")]
        public async Task<IActionResult> PutGame([FromBody]GameDto gameDto)
        {
            await _gameService.UpdateAsync(gameDto);
            return Ok("Game updated");
        }

        [HttpDelete]
        [Route("api/game/{id}")]
        public async Task<IActionResult> DeleteGame(int id)
        {
            await _gameService.DeleteAsync(id);
            return Ok("Game deleted");
        }
    }
}