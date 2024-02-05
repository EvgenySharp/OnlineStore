using Auth.BuisnessLayer.DTOs.ResponseDTOs;
using Auth.DataAccessLayer.Entity;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace Auth.BuisnessLayer.Common.Mappings
{
    internal class RoleResponseDtoMap : Profile
    {
        public RoleResponseDtoMap()
        {
            CreateMap<IdentityRole, RoleResponseDto>()
                .ForMember(roleResponseDto => roleResponseDto.Name,
                    opt => opt.MapFrom(entityRole => entityRole.Name));
        }
    }
}