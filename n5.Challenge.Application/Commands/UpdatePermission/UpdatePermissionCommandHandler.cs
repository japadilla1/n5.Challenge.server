using AutoMapper;
using MediatR;
using n5.Challenge.Application.Dto;
using n5.Challenge.Application.UnitOfWork;
using n5.Challenge.Domain.Entities;

namespace n5.Challenge.Application.Commands.UpdatePermission
{
    public class UpdatePermissionCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<UpdatePermissionCommand, PermissionDto>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IMapper _mapper = mapper;

        public async Task<PermissionDto> Handle(UpdatePermissionCommand request, CancellationToken cancellationToken)
        {
            var permission = _mapper.Map<Permission>(request);
            var response = await _unitOfWork.PermissionRepository.ModifyAsync(permission);
            await _unitOfWork.CompleteAsync();
            var permissionResponse = _mapper.Map<PermissionDto>(response);
            return permissionResponse;
        }
    }
}
