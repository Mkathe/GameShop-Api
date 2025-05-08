using GameShop_Api.Data;
using GameShop_Api.DTOs.SystemRequirementDto;
using GameShop_Api.Entities.Models;
using GameShop_Api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GameShop_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SystemRequirementController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ISystemRepository _repo;
        public SystemRequirementController(AppDbContext context, ISystemRepository repo)
        {
            _context = context;
            _repo = repo;
        }
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetAllSystemRequirements()
        {
            var requirements = await _repo.GetAllRequirementsAsync();
            if (requirements is null)
            {
                return NotFound("This system requirement cannot be found from db");
            }
            return Ok(requirements);
        }
        [HttpGet("{id:guid}", Name = nameof(GetSystemRequirementsById))]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetSystemRequirementsById([FromRoute] Guid id)
        {
            var requirement = await _repo.GetByIdRequirement(id);
            if (requirement is null)
            {
                return NotFound("The system requirement cannot be found by this id");
            }
            return Ok(requirement);
        }
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> AddGame([FromBody] CreateSystemRequirementDto requirementDto)
        {
            var requirementModel = new SystemRequirement
            {
                GameId = requirementDto.GameId,
                DiskSpace = requirementDto.DiskSpace,
                Memory = requirementDto.Memory,
                Processor = requirementDto.Processor,
                VideoCard = requirementDto.VideoCard,
                Windows = requirementDto.Windows,
            };
            if (requirementModel is null)
            {
                return BadRequest();
            }
            await _repo.CreateRequirementAsync(requirementModel);
            return CreatedAtRoute(nameof(GetSystemRequirementsById), new { id = requirementModel.GameId }, requirementDto);
        }
        [HttpPut("{id:guid}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateSystemRequirement([FromRoute] Guid id, [FromBody] UpdateSystemRequirementDto requirementDto)
        {

            var existingRequirement = await _repo.UpdateRequirementAsync(id, requirementDto);
            if (existingRequirement is null)
            {
                return NotFound();
            }
            return NoContent();
        }
        [HttpDelete("{id:guid}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteSystemRequirement([FromRoute] Guid id)
        {
            var requirement = await _repo.DeleteRequirementAsync(id);
            if (requirement is null)
            {
                return NotFound("The system requirement cannot be found from repository or database");
            }
            return NoContent();
        }
    }
}
