using GameShop_Api.Data;
using GameShop_Api.DTOs.GameDto;
using GameShop_Api.Entities.Models;
using GameShop_Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GameShop_Api.Repositories
{
    public class GameRepository : IGameRepository
    {
        private readonly AppDbContext _context;
        public GameRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Game> CreateGameAsync(Game game)
        {
            await _context.Games.AddAsync(game);
            await _context.SaveChangesAsync();
            return game;
        }
        public async Task<List<Game>> GetAllGamesAsync()
        {
            var games = await _context.Games.ToListAsync();
            if (games is null)
            {
                return null!;
            }
            return games;
        }
        public async Task<Game?> GetGameByIdAsync(Guid id)
        {
            var game = await _context.Games.FindAsync(id);
            if (game is null)
            {
                return null!;
            }
            return game;
        }
        public async Task<Game?> UpdateGameAsync(Guid id, UpdateGameFromDto gameDto)
        {
            var existing = await _context.Games.FindAsync(id);
            if (existing is null)
            {
                return null!;
            }
            existing.GameName = gameDto.GameName;
            existing.GameGenre = gameDto.GameGenre;
            existing.GamePublisher = gameDto.GamePublisher;
            existing.GameReleaseYear = gameDto.GameReleaseYear;
            existing.GameSound = gameDto.GameSound;
            existing.GameText = gameDto.GameText;
            await _context.SaveChangesAsync();
            return existing;
        }
        public async Task<Game?> DeleteGameAsync(Guid id)
        {
            var game = await _context.Games.FindAsync(id);
            if (game is null)
            {
                return null!;
            }
            _context.Games.Remove(game);
            await _context.SaveChangesAsync();
            return game;
        }
    }
}
