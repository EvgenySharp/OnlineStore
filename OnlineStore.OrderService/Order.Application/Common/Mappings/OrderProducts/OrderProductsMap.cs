using AutoMapper;
using Order.Application.DTOs.RequestDtos.OrderProducts;
using Order.Domain.Entities;

namespace Order.Application.Common.Mappings.OrderProducts
{
    public class OrderProductsMap : Profile
    {
        public OrderProductsMap()
        {
            CreateMap<CreateOrderProductsRequestDto, OrderProductsEntity>()
                .ForMember(orderProductsEntity => orderProductsEntity.ProductIds,
                    opt => opt.MapFrom(orderProductsDto => orderProductsDto.ProductIds));
        }
    }
}