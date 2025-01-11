using n5.Challenge.Domain.Entities;

namespace n5.Challenge.Application.Repositories
{
    public interface IPermissionTypeRepository
    {
        Task<IReadOnlyList<PermissionType>> GetAllAsync();
    }
}
