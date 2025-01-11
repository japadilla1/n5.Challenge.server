using MediatR;
using n5.Challenge.Application.Dto;

namespace n5.Challenge.Application.Queries.GetAllPermissionType
{
    public class GetAllPermissionTypeQuery : IRequest<IReadOnlyList<PermissionTypeDto>>
    {
    }
}
