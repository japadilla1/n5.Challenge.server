
using MediatR;
using n5.Challenge.Application.Dto;

namespace n5.Challenge.Application.Queries.GetAllPermission
{
    public class GetAllPermissionQuery: IRequest<IReadOnlyList<PermissionDto>>
    {
    }
}
