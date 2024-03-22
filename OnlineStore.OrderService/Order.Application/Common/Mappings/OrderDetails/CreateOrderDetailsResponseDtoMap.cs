using AutoMapper;
using Order.Application.DTOs.ResponseDtos.OrderDetails;
using Order.Domain.Entities;

namespace Order.Application.Common.Mappings.OrderDetails
{
    public class CreateOrderDetailsResponseDtoMap : Profile
    {
        public CreateOrderDetailsResponseDtoMap()
        {
            CreateMap<OrderDetailsEntity, CreateOrderDetailsResponseDto>()
                .ForMember(orderDetailsDto => orderDetailsDto.Id,
                    opt => opt.MapFrom(orderDetailsEntity => orderDetailsEntity.Id));
        }
    }
}