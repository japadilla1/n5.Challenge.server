using Microsoft.EntityFrameworkCore;
using n5.Challenge.Domain.Entities;

namespace n5.Challenge.Infrastructure.Seed
{
    public static class SeedData
    {
        public static void Initialize(this ModelBuilder modelBuilder) {
            modelBuilder.Entity<PermissionType>().HasData(
                new PermissionType { 
                    Id = 1, 
                    Description = "SuperAdmin"
                },
                new PermissionType
                {
                    Id = 2,
                    Description = "Admin"
                },
                new PermissionType
                {
                    Id = 3,
                    Description = "Supervisor"
                }
                );
        }
    }
}
