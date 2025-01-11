using Microsoft.EntityFrameworkCore;
using n5.Challenge.Domain.Entities;
using n5.Challenge.Infrastructure.Seed;

namespace n5.Challenge.Infrastructure.Context
{
    public class PermissionDbContext(DbContextOptions<PermissionDbContext> options) : DbContext(options)
    {
        public DbSet<Permission> Permission { get; set; }

        public DbSet<PermissionType> PermissionType { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Initialize();
        }

    }
}
