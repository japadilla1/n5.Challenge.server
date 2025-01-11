using n5.Challenge.Domain.Entities;

namespace n5.Challenge.Application.Repositories
{
    public interface IPermissionRepository
    {
        Task<IReadOnlyList<Permission>> GetAllAsync();

        Task<Permission> AddAsync(Permission input);

        Task<Permission> ModifyAsync(Permission input);
    }
}
