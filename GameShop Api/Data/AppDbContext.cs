using GameShop_Api.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace GameShop_Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Game> Games { get; set; }
        public DbSet<SystemRequirement> SystemRequirements { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>(entity =>
            {
                entity.HasOne(p => p.SystemRequirementNavigation)
                .WithOne(w => w.GameNavigation)
                .HasForeignKey<SystemRequirement>(f => f.GameId)
                .IsRequired();
            });
            modelBuilder.Entity<SystemRequirement>(entity =>
            {
                entity.HasKey(k => k.GameId);
            });
            modelBuilder.Seed();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.ConfigureWarnings(w => w.Ignore(RelationalEventId.PendingModelChangesWarning));
        }
    }
}
