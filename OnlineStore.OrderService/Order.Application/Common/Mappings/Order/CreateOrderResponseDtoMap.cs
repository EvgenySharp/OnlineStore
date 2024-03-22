using AutoMapper;
using Order.Application.DTOs.ResponseDtos.Orders;
using Order.Domain.Entities;

namespace Order.Application.Common.Mappings.Order
{
    public class CreateOrderResponseDtoMap : Profile
    {
        public CreateOrderResponseDtoMap()
        {
            CreateMap<OrderEntity, CreateOrderResponseDto>()
                .ForMember(orderDto => orderDto.Id,
                    opt => opt.MapFrom(orderEntity => orderEntity.Id));
        }
    }
}