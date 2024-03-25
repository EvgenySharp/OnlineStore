using AutoMapper;
using Order.Application.DTOs.RequestDtos.OrderDetails;
using Order.Application.DTOs.RequestDtos.Orders;

namespace Order.Application.Common.Mappings.OrderDetails
{
    public class CreateOrderDetailsRequestDtoMap : Profile
    {
        public CreateOrderDetailsRequestDtoMap()
        {
            CreateMap<CreateOrderRequestDto, CreateOrderDetailsRequestDto>()
                .ForMember(orderDetails => orderDetails.FirstName,
                    opt => opt.MapFrom(order => order.FirstName))
                .ForMember(orderDetails => orderDetails.LastName,
                    opt => opt.MapFrom(order => order.LastName))
                .ForMember(orderDetails => orderDetails.Email,
                    opt => opt.MapFrom(order => order.Email))
                .ForMember(orderDetails => orderDetails.Address,
                    opt => opt.MapFrom(order => order.Address))
                .ForMember(orderDetails => orderDetails.Town,
                    opt => opt.MapFrom(order => order.Town))
                .ForMember(orderDetails => orderDetails.Comment,
                    opt => opt.MapFrom(order => order.Comment));
        }
    }
}