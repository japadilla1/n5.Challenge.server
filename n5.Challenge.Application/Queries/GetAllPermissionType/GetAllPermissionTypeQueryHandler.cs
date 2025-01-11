using MediatR;
using n5.Challenge.Application.Dto;
using n5.Challenge.Application.Queries.GetAllPermission;
using n5.Challenge.Application.Repositories;

namespace n5.Challenge.Application.Queries.GetAllPermissionType
{
    public class GetAllPermissionTypeQueryHandler(IPermissionTypeRepository permissionTypeRepository) : IRequestHandler<GetAllPermissionTypeQuery, IReadOnlyList<PermissionTypeDto>>
    {
        private readonly IPermissionTypeRepository _permissionsRepository = permissionTypeRepository;

        public async Task<IReadOnlyList<PermissionTypeDto>> Handle(GetAllPermissionTypeQuery request, CancellationToken cancellationToken)
        {
            var response = await permissionTypeRepository.GetAllAsync();
            var data = response.Select(p => new PermissionTypeDto
            {
                Id = p.Id,
                Description = p.Description
            }).ToList();
            return data;
        }
    }
}
