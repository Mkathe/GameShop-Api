using GameShop_Api.Data;
using GameShop_Api.DTOs.SystemRequirementDto;
using GameShop_Api.Entities.Models;
using GameShop_Api.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace GameShop_Api.Repositories
{
    public class SystemRequirementRepository : ISystemRepository
    {
        private readonly AppDbContext _context;
        public SystemRequirementRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<SystemRequirement> CreateRequirementAsync(SystemRequirement requirement)
        {
            if (requirement is null)
            {
                return null!;
            }
            await _context.SystemRequirements.AddAsync(requirement);
            await _context.SaveChangesAsync();
            return requirement;
        }

        public async Task<SystemRequirement?> DeleteRequirementAsync(Guid id)
        {
            var existing = await _context.SystemRequirements.FindAsync(id);
            if (existing is null)
            {
                return null;
            }
            _context.SystemRequirements.Remove(existing);
            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<List<SystemRequirement>> GetAllRequirementsAsync()
        {
            var requirements = await _context.SystemRequirements.ToListAsync();
            if (requirements is null)
            {
                return null!;
            }
            return requirements;
        }

        public async Task<SystemRequirement?> GetByIdRequirement(Guid id)
        {
            var existing = await _context.SystemRequirements.FindAsync(id);
            if (existing is null)
            {
                return null!;
            }
            return existing;
        }

        public async Task<SystemRequirement?> UpdateRequirementAsync(Guid id, UpdateSystemRequirementDto requirement)
        {
            var existing = await _context.SystemRequirements.FindAsync(id);
            if (existing is null)
            {
                return null!;
            }
            existing.Windows = requirement.Windows;
            existing.Processor = requirement.Processor;
            existing.DiskSpace = requirement.DiskSpace;
            await _context.SaveChangesAsync();
            return existing;
        }
    }
}
