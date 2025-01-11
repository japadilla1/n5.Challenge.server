using AutoMapper;
using MediatR;
using n5.Challenge.Application.Dto;
using n5.Challenge.Application.UnitOfWork;

namespace n5.Challenge.Application.Queries.GetAllPermissionType
{
    public class GetAllPermissionTypeQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<GetAllPermissionTypeQuery, IReadOnlyList<PermissionTypeDto>>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IMapper _mapper = mapper;

        public async Task<IReadOnlyList<PermissionTypeDto>> Handle(GetAllPermissionTypeQuery request, CancellationToken cancellationToken)
        {
            var response = await _unitOfWork.PermissionTypeRepository.GetAllAsync();
            var responseMap = _mapper.Map<IReadOnlyList<PermissionTypeDto>>(response);
            return responseMap;
        }
    }
}
