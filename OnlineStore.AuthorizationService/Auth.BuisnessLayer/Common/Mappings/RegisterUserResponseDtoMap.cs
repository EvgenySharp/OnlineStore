using Auth.BuisnessLayer.DTOs.ResponseDTOs;
using Auth.DataAccessLayer.Entity;
using AutoMapper;

namespace Auth.BuisnessLayer.Common.Mappings
{
    internal class RegisterUserResponseDtoMap : Profile
    {
        public RegisterUserResponseDtoMap()
        {
            CreateMap<User, RegisterUserResponseDto>()
                .ForMember(registerUser => registerUser.Name,
                    opt => opt.MapFrom(entityUser => entityUser.UserName))
                .ForMember(registerUser => registerUser.Role,
                    opt => opt.MapFrom(entityUser => entityUser.Role));
        }
    }
}