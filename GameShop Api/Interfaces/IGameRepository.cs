using GameShop_Api.DTOs.GameDto;
using GameShop_Api.Entities.Models;

namespace GameShop_Api.Interfaces
{
    public interface IGameRepository
    {
        Task<List<Game>> GetAllGamesAsync();
        Task<Game?> GetGameByIdAsync(Guid id);
        Task<Game> CreateGameAsync(Game game);
        Task<Game?> UpdateGameAsync(Guid id, UpdateGameFromDto game);
        Task<Game?> DeleteGameAsync(Guid id);
    }
}
