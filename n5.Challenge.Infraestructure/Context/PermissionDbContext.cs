using Microsoft.EntityFrameworkCore;
using n5.Challenge.Domain.Entities;

namespace n5.Challenge.Infrastructure.Context
{
    public class PermissionDbContext(DbContextOptions<PermissionDbContext> options) : DbContext(options)
    {
        public DbSet<Permission> Permission { get; set; }
        public DbSet<PermissionType> PermissionType { get; set; }
    }
}
