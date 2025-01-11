using n5.Challenge.Application.Repositories;

namespace n5.Challenge.Application.UnitOfWork
{
    public interface IUnitOfWork: IDisposable
    {
        IPermissionRepository PermissionRepository { get; }

        IPermissionTypeRepository PermissionTypeRepository { get; }

        Task<int> CompleteAsync();
    }
}
