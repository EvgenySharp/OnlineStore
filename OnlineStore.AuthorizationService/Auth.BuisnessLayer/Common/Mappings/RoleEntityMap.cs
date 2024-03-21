using Auth.BuisnessLayer.DTOs.RequestDTOs;
using Auth.DataAccessLayer.Entity;
using AutoMapper;

namespace Auth.BuisnessLayer.Common.Mappings
{
    internal class RoleEntityMap : Profile
    {
        public RoleEntityMap()
        {
            CreateMap<RoleRequestDto, Role>()
                .ForMember(entityRole => entityRole.Name,
                    opt => opt.MapFrom(roleRequest => roleRequest.Name));
        }
    }
}