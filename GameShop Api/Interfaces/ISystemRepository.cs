using GameShop_Api.DTOs.SystemRequirementDto;
using GameShop_Api.Entities.Models;

namespace GameShop_Api.Interfaces
{
    public interface ISystemRepository
    {
        Task<List<SystemRequirement>> GetAllRequirementsAsync();
        Task<SystemRequirement?> GetByIdRequirement(Guid id);
        Task<SystemRequirement> CreateRequirementAsync(SystemRequirement requirement);
        Task<SystemRequirement?> UpdateRequirementAsync(Guid id, UpdateSystemRequirementDto requirement);
        Task<SystemRequirement?> DeleteRequirementAsync(Guid id);
    }
}
