using AutoMapper;
using Order.Application.DTOs.ResponseDtos.Orders;
using Order.Domain.Entities;

namespace Order.Application.Common.Mappings.Order
{
    public class GetOrderResponseDtoMap : Profile
    {
        public GetOrderResponseDtoMap()
        {
            CreateMap<OrderEntity, GetOrderResponseDto>()
                .ForMember(orderDto => orderDto.Id,
                    opt => opt.MapFrom(orderEntity => orderEntity.Id));
        }
    }
}