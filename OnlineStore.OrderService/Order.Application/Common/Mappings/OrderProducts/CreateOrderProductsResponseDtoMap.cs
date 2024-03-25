using AutoMapper;
using Order.Application.DTOs.ResponseDtos.OrderProducts;
using Order.Domain.Entities;

namespace Order.Application.Common.Mappings.OrderProducts
{
    public class CreateOrderProductsResponseDtoMap : Profile
    {
        public CreateOrderProductsResponseDtoMap() 
        {
            CreateMap<OrderProductsEntity, CreateOrderProductsResponseDto>()
                .ForMember(orderProductsDto => orderProductsDto.Id,
                    opt => opt.MapFrom(orderProductsEntity => orderProductsEntity.Id));
        }
    }
}