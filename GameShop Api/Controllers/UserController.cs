using GameShop_Api.Data;
using GameShop_Api.DTOs.UserDto;
using GameShop_Api.Entities.Models;
using GameShop_Api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GameShop_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IUserRepository _repo;
        public UserController(AppDbContext context, IUserRepository repo)
        {
            _repo = repo;
        }
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _repo.GetAllUsersAsync();
            if (users is null)
            {
                return NotFound("User cannot be found from db");
            }
            return Ok(users);
        }
        [HttpGet("{id:guid}", Name = nameof(GetUserById))]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetUserById([FromRoute] Guid id)
        {
            var user = await _repo.GetUserByIdAsync(id);
            if (user is null)
            {
                return NotFound("The user can not be found by this id");
            }
            return Ok(user);
        }
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> AddUser([FromBody] CreateUserDto userDto)
        {
            var userModel = new User
            {
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Age = userDto.Age,
            };
            if (userModel is null)
            {
                return BadRequest();
            }
            await _repo.CreateUserAsync(userModel);
            return CreatedAtRoute(nameof(GetUserById), new { id = userModel.Id }, userDto);
        }
        [HttpPut("{id:guid}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateUser([FromRoute] Guid id, [FromBody] UpdateUserDto userDto)
        {

            var existingUser = await _repo.UpdateUserAsync(id, userDto);
            if (existingUser is null)
            {
                return NotFound();
            }
            return NoContent();
        }
        [HttpDelete("{id:guid}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteUser([FromRoute] Guid id)
        {
            var user = await _repo.DeleteUserAsync(id);
            if (user is null)
            {
                return NotFound("This user cannot be found from repository or database");
            }
            return NoContent();
        }
    }
}
