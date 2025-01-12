using AutoMapper;
using MediatR;
using n5.Challenge.Application.Dto;
using n5.Challenge.Application.UnitOfWork;
using n5.Challenge.Domain.Entities;
using Nest;

namespace n5.Challenge.Application.Commands.UpdatePermission
{
    public class UpdatePermissionCommandHandler(IUnitOfWork unitOfWork, IElasticClient elastic,IMapper mapper) : IRequestHandler<UpdatePermissionCommand, PermissionDto>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IMapper _mapper = mapper;
        private readonly IElasticClient _elastic = elastic;

        public async Task<PermissionDto> Handle(UpdatePermissionCommand request, CancellationToken cancellationToken)
        {
            var permission = _mapper.Map<Permission>(request);
            var response = await _unitOfWork.PermissionRepository.ModifyAsync(permission);
            await _unitOfWork.CompleteAsync();
            await _elastic.IndexDocumentAsync(response, cancellationToken);
            var permissionResponse = _mapper.Map<PermissionDto>(response);
            return permissionResponse;
        }
    }
}
