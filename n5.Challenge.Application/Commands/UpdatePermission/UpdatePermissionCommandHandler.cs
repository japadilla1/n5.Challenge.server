using MediatR;
using n5.Challenge.Application.Dto;
using n5.Challenge.Application.Repositories;
using n5.Challenge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace n5.Challenge.Application.Commands.UpdatePermission
{
    public class UpdatePermissionCommandHandler(IPermissionRepository permissionsRepository) : IRequestHandler<UpdatePermissionCommand, PermissionDto>
    {
        private readonly IPermissionRepository _permissionsRepository = permissionsRepository;

        public async Task<PermissionDto> Handle(UpdatePermissionCommand request, CancellationToken cancellationToken)
        {
            var permission = new Permission()
            {
                Id = request.Id,
                EmployeeName = request.EmployeeName,
                EmployeeSurname = request.EmployeeSurname,
                PermissionDate = request.PermissionDate,
                PermissionTypeId = request.PermissionTypeId,
            };
            var response = await _permissionsRepository.ModifyAsync(permission);
            var permissionResponse = new PermissionDto()
            {
                Id = response.Id,
                EmployeeName = response.EmployeeName,
                EmployeeSurname = response.EmployeeSurname,
                PermissionDate = response.PermissionDate,
                PermissionTypeId = response.PermissionTypeId,
            };
            return permissionResponse;
        }
    }
}
