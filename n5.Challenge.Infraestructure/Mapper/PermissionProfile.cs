using AutoMapper;
using n5.Challenge.Application.Commands.AddPermission;
using n5.Challenge.Application.Commands.UpdatePermission;
using n5.Challenge.Application.Dto;
using n5.Challenge.Domain.Entities;

namespace n5.Challenge.Infrastructure.Mapper
{
    public class PermissionProfile: Profile
    {
        public PermissionProfile()
        {
            CreateMap<AddPermissionCommand, Permission>().ReverseMap();
            CreateMap<UpdatePermissionCommand, Permission>().ReverseMap();
            CreateMap<PermissionDto, Permission>()
                .ForPath(dest => dest.PermissionType.Description, opt => opt.MapFrom(src => src.Description))
                .ReverseMap();
            CreateMap<PermissionTypeDto, PermissionType>().ReverseMap();
            
        }
    }
}
