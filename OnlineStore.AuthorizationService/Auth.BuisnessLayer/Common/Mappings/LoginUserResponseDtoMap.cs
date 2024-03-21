using Auth.BuisnessLayer.DTOs.ResponseDTOs;
using Auth.DataAccessLayer.Entity;
using AutoMapper;

namespace Auth.BuisnessLayer.Common.Mappings
{
    internal class LoginUserResponseDtoMap :  Profile
    {
        public LoginUserResponseDtoMap() 
        {
            CreateMap<User, LoginUserResponseDto>()
                .ForMember(loginUser => loginUser.Name,
                    opt => opt.MapFrom(entityUser => entityUser.UserName))
                .ForMember(loginUser => loginUser.Role,
                    opt => opt.MapFrom(entityUser => entityUser.Role));
        }
    }
}