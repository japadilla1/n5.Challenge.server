﻿using Microsoft.EntityFrameworkCore;
using n5.Challenge.Application.Repositories;
using n5.Challenge.Domain.Entities;
using n5.Challenge.Infrastructure.Context;
using Nest;

namespace n5.Challenge.Infrastructure.Repositories
{
    public class PermissionRepository(PermissionDbContext context) : IPermissionRepository
    {
        private readonly PermissionDbContext _context = context;

        public async Task<Permission> AddAsync(Permission input)
        {
            await _context.Permission.AddAsync(input);        
            return input;
        }

        public async Task<IReadOnlyList<Permission>> GetAllAsync()
        {
            var permissions = await _context.Permission.Include(nameof(PermissionType)).ToListAsync();
            return permissions;
        }

        public async Task<Permission> ModifyAsync(Permission input)
        {
            if(input.Id == 0)
            {
                throw new ArgumentException("El campo Id es obligatorio");
            }
            _context.Permission.Update(input);
            await Task.CompletedTask;
            return input;
        }
    }
}
