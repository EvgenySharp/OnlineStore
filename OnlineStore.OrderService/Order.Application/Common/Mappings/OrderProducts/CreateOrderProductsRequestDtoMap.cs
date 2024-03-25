using AutoMapper;
using Order.Application.DTOs.RequestDtos.OrderProducts;
using Order.Application.DTOs.RequestDtos.Orders;

namespace Order.Application.Common.Mappings.OrderProducts
{
    public class CreateOrderProductsRequestDtoMap : Profile
    {
        public CreateOrderProductsRequestDtoMap()
        {
            CreateMap<CreateOrderRequestDto, CreateOrderProductsRequestDto>()
                .ForMember(orderProducts => orderProducts.ProductIds,
                    opt => opt.MapFrom(order => order.ProductIds));
        }
    }
}