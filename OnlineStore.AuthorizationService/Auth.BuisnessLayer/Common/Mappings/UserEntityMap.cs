using Auth.BuisnessLayer.DTOs.RequestDTOs;
using Auth.DataAccessLayer.Entity;
using AutoMapper;

namespace Auth.BuisnessLayer.Common.Mappings
{
    internal class UserEntityMap : Profile
    {
        public UserEntityMap()
        {
            CreateMap<RegisterUserRequestDto, User>()
                .ForMember(entityUser => entityUser.UserName,
                    opt => opt.MapFrom(registerUser => registerUser.Name));
        }
    }
}