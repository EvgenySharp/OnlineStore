using AutoMapper;
using Order.Application.DTOs.ResponseDtos.OrderProducts;
using Order.Domain.Entities;

namespace Order.Application.Common.Mappings.OrderProducts
{
    public class GetOrderProductsResponseDtoMap : Profile
    {
        public GetOrderProductsResponseDtoMap()
        {
            CreateMap<OrderProductsEntity, GetOrderProductsResponseDto>()
                .ForMember(orderDto => orderDto.Id,
                    opt => opt.MapFrom(orderEntity => orderEntity.Id));
        }
    }
}