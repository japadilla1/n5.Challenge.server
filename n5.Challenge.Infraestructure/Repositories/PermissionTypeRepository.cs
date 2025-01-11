using Microsoft.EntityFrameworkCore;
using n5.Challenge.Application.Repositories;
using n5.Challenge.Domain.Entities;
using n5.Challenge.Infrastructure.Context;

namespace n5.Challenge.Infrastructure.Repositories
{
    public class PermissionTypeRepository(PermissionDbContext context): IPermissionTypeRepository
    {
        private readonly PermissionDbContext _context = context;

        public async Task<IReadOnlyList<PermissionType>> GetAllAsync()
        {
            var permissionType = await _context.PermissionType.ToListAsync();
            return permissionType;
        }
    }
}
