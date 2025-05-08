using GameShop_Api.DTOs.UserDto;
using GameShop_Api.Entities.Models;

namespace GameShop_Api.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUsersAsync();
        Task<User?> GetUserByIdAsync(Guid id);
        Task<User> CreateUserAsync(User user);
        Task<User?> UpdateUserAsync(Guid id, UpdateUserDto userDto);
        Task<User?> DeleteUserAsync(Guid id);
    }
}
