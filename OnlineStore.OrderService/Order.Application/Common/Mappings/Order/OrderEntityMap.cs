using AutoMapper;
using Order.Application.DTOs.ResponseDtos.OrderDetails;
using Order.Domain.Entities;

namespace Order.Application.Common.Mappings.Order
{
    public class OrderEntityMap : Profile
    {
        public OrderEntityMap()
        {
            CreateMap<CreateOrderDetailsResponseDto, OrderEntity>()
                .ForMember(orderEntity => orderEntity.IdOrderDetails,
                    opt => opt.MapFrom(orderDetailsDto => orderDetailsDto.Id));
        }
    }
}