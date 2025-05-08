using GameShop_Api.Data;
using GameShop_Api.DTOs.GameDto;
using GameShop_Api.Entities.Models;
using GameShop_Api.Interfaces;
using Microsoft.AspNetCore.Mvc;
namespace GameShop_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IGameRepository _repo;
        public GameController(AppDbContext context, IGameRepository repo)
        {
            _context = context;
            _repo = repo;
        }
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetAllGames()
        {
            var games = await _repo.GetAllGamesAsync();
            if (games is null)
            {
                return NotFound("Game cannot be found from db");
            }
            return Ok(games);
        }
        [HttpGet("{id:guid}", Name = nameof(GetGameById))]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetGameById([FromRoute] Guid id)
        {
            var game = await _repo.GetGameByIdAsync(id);
            if (game is null)
            {
                return NotFound("The game can not be found by this id");
            }
            return Ok(game);
        }
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> AddGame([FromBody] CreateGameFromDto gameDto)
        {
            var gameModel = new Game
            {
                Id = Guid.NewGuid(),
                GameName = gameDto.GameName,
                GameGenre = gameDto.GameGenre,
                GamePublisher = gameDto.GamePublisher,
                GameReleaseYear = gameDto.GameReleaseYear,
                GameSound = gameDto.GameSound,
                GameText = gameDto.GameText,
            };
            if (gameModel is null)
            {
                return BadRequest();
            }
            await _repo.CreateGameAsync(gameModel);
            return CreatedAtRoute(nameof(GetGameById), new { id = gameModel.Id }, gameDto);
        }
        [HttpPut("{id:guid}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateGame([FromRoute] Guid id, [FromBody] UpdateGameFromDto gameDto)
        {

            var existingGame = await _repo.UpdateGameAsync(id, gameDto);
            if (existingGame is null)
            {
                return NotFound();
            }
            return NoContent();
        }
        [HttpDelete("{id:guid}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteGame([FromRoute] Guid id)
        {
            var game = await _repo.DeleteGameAsync(id);
            if (game is null)
            {
                return NotFound("Game cannot be found from repository or database");
            }
            return NoContent();
        }
    }
}
