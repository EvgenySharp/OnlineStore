using AutoMapper;
using Order.Application.DTOs.RequestDtos.OrderDetails;
using Order.Domain.Entities;

namespace Order.Application.Common.Mappings.OrderDetails
{
    public class OrderDetailsEntityMap : Profile
    {
        public OrderDetailsEntityMap()
        {
            CreateMap<CreateOrderDetailsRequestDto, OrderDetailsEntity>()
                .ForMember(orderDetailsEntity => orderDetailsEntity.FirstName,
                    opt => opt.MapFrom(orderProductsDto => orderProductsDto.FirstName))
                .ForMember(orderDetailsEntity => orderDetailsEntity.LastName,
                    opt => opt.MapFrom(orderProductsDto => orderProductsDto.LastName))
                .ForMember(orderDetailsEntity => orderDetailsEntity.Email,
                    opt => opt.MapFrom(orderProductsDto => orderProductsDto.Email))
                .ForMember(orderDetailsEntity => orderDetailsEntity.Address,
                    opt => opt.MapFrom(orderProductsDto => orderProductsDto.Address))
                .ForMember(orderDetailsEntity => orderDetailsEntity.Town,
                    opt => opt.MapFrom(orderProductsDto => orderProductsDto.Town))
                .ForMember(orderDetailsEntity => orderDetailsEntity.Comment,
                    opt => opt.MapFrom(orderProductsDto => orderProductsDto.Comment));
        }
    }
}