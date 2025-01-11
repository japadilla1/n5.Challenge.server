using AutoMapper;
using MediatR;
using n5.Challenge.Application.UnitOfWork;
using n5.Challenge.Domain.Entities;
using Nest;

namespace n5.Challenge.Application.Commands.AddPermission
{
    public class AddPermissionCommandHandler(IUnitOfWork unitOfWork, IElasticClient elastic, IMapper mapper) : IRequestHandler<AddPermissionCommand, bool>
    {
        private readonly IElasticClient _elastic = elastic;
        private readonly IMapper _mapper = mapper;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<bool> Handle(AddPermissionCommand request, CancellationToken cancellationToken)
        {
            var permission = _mapper.Map<Permission>(request);
            var response = await _unitOfWork.PermissionRepository.AddAsync(permission);
            await _unitOfWork.CompleteAsync();
            await _elastic.IndexDocumentAsync(response, cancellationToken);
            return true;
        }
    }
}
