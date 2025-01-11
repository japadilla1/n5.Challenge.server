using MediatR;
using n5.Challenge.Application.Dto;
using n5.Challenge.Application.Repositories;

namespace n5.Challenge.Application.Queries.GetAllPermission
{
    public class GetAllPermissionQueryHandler(IPermissionRepository permissionsRepository) : IRequestHandler<GetAllPermissionQuery, IReadOnlyList<PermissionDto>>
    {
        private readonly IPermissionRepository _permissionsRepository = permissionsRepository;

        public async Task<IReadOnlyList<PermissionDto>> Handle(GetAllPermissionQuery request, CancellationToken cancellationToken)
        {
            var response = await _permissionsRepository.GetAllAsync();
            var data = response.Select(p => new PermissionDto
            {
                Id = p.Id,
                EmployeeName = p.EmployeeName,
                EmployeeSurname = p.EmployeeSurname,
                PermissionDate = p.PermissionDate,
                PermissionTypeId = p.PermissionTypeId,
            }).ToList();
            return data;
        }
    }

}
