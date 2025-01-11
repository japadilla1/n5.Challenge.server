using AutoMapper;
using MediatR;
using n5.Challenge.Application.Dto;
using n5.Challenge.Application.UnitOfWork;

namespace n5.Challenge.Application.Queries.GetAllPermission
{
    public class GetAllPermissionQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<GetAllPermissionQuery, IReadOnlyList<PermissionDto>>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IMapper _mapper = mapper;

        public async Task<IReadOnlyList<PermissionDto>> Handle(GetAllPermissionQuery request, CancellationToken cancellationToken)
        {
            var response = await _unitOfWork.PermissionRepository.GetAllAsync();
            var responseMap = _mapper.Map<IReadOnlyList<PermissionDto>>(response);
           
            return responseMap;
        }
    }

}
