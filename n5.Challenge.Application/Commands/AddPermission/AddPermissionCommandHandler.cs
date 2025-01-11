using MediatR;
using n5.Challenge.Application.Repositories;
using n5.Challenge.Domain.Entities;

namespace n5.Challenge.Application.Commands.AddPermission
{
    public class AddPermissionCommandHandler(IPermissionRepository permissionsRepository) : IRequestHandler<AddPermissionCommand, bool>
    {
        private readonly IPermissionRepository _permissionsRepository = permissionsRepository;

        public async Task<bool> Handle(AddPermissionCommand request, CancellationToken cancellationToken)
        {
            var permission = new Permission()
            {
                EmployeeName = request.EmployeeName,
                EmployeeSurname = request.EmployeeSurname,
                PermissionDate = request.PermissionDate,
                PermissionTypeId = request.PermissionTypeId,
            };
            await _permissionsRepository.AddAsync(permission);

            return true;
        }
    }
}
