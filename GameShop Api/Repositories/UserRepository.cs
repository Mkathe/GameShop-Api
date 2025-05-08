using GameShop_Api.Data;
using GameShop_Api.DTOs.UserDto;
using GameShop_Api.Entities.Models;
using GameShop_Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GameShop_Api.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<User> CreateUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> DeleteUserAsync(Guid id)
        {
            var users = await _context.Users.FindAsync(id);
            if (users is null)
            {
                return null!;
            }
            _context.Users.Remove(users);
            await _context.SaveChangesAsync();
            return users;
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            var users = await _context.Users.ToListAsync();
            if (users is null)
            {
                return null!;
            }
            return users;
        }

        public async Task<User> GetUserByIdAsync(Guid id)
        {
            var users = await _context.Users.FindAsync(id);
            if (users is null)
            {
                return null!;
            }
            return users;
        }

        public async Task<User> UpdateUserAsync(Guid id, UpdateUserDto userDto)
        {
            var existing = await _context.Users.FindAsync(id);
            if (existing is null)
            {
                return null!;
            }
            existing.FirstName = userDto.FirstName;
            existing.LastName = userDto.LastName;
            existing.Age = userDto.Age;
            await _context.SaveChangesAsync();
            return existing;
        }
    }
}
