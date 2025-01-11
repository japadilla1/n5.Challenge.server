using n5.Challenge.Application.Repositories;
using n5.Challenge.Application.UnitOfWork;
using n5.Challenge.Infrastructure.Context;
using n5.Challenge.Infrastructure.Repositories;

namespace n5.Challenge.Infrastructure.UnitOfWork
{
    public class UnitOfWork(PermissionDbContext context) : IUnitOfWork
    {
        public IPermissionRepository PermissionRepository { get; private set; } = new PermissionRepository(context);

        public IPermissionTypeRepository PermissionTypeRepository { get; private set; } = new PermissionTypeRepository(context);

        private readonly PermissionDbContext _context = context;

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
