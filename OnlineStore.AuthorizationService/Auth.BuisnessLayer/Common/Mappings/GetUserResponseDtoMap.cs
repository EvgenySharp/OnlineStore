using Auth.BuisnessLayer.DTOs.ResponseDTOs;
using Auth.DataAccessLayer.Entity;
using AutoMapper;

namespace Auth.BuisnessLayer.Common.Mappings
{
    internal class GetUserResponseDtoMap : Profile
    {
        public GetUserResponseDtoMap()
        {
            CreateMap<User, GetUserResponseDto>()
                .ForMember(registerUser => registerUser.Id,
                    opt => opt.MapFrom(entityUser => entityUser.Id))
                .ForMember(registerUser => registerUser.Name,
                    opt => opt.MapFrom(entityUser => entityUser.UserName))
                .ForMember(registerUser => registerUser.Role,
                    opt => opt.MapFrom(entityUser => entityUser.Role));
        }
    }
}