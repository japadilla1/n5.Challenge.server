using Microsoft.EntityFrameworkCore;
using n5.Challenge.Application.Repositories;
using n5.Challenge.Domain.Entities;
using n5.Challenge.Infrastructure.Context;

namespace n5.Challenge.Infrastructure.Repositories
{
    public class PermissionRepository(PermissionDbContext context) : IPermissionRepository
    {
        private readonly PermissionDbContext _context = context;

        public async Task<Permission> AddAsync(Permission input)
        {
            await _context.Permission.AddAsync(input);
            await _context.SaveChangesAsync();
            return input;
        }

        public async Task<IReadOnlyList<Permission>> GetAllAsync()
        {
            var permissions = await _context.Permission.ToListAsync();
            return permissions;
        }

        public async Task<Permission> ModifyAsync(Permission input)
        {
            _context.Permission.Update(input);

            await _context.SaveChangesAsync();

            return input;
        }
    }
}
