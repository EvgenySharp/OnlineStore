using Order.Application.DTOs.RequestDtos.OrderDetails;
using Order.Application.DTOs.ResponseDtos.OrderDetails;

namespace Order.Application.Abstractions.Interfaces
{
    public interface IOrderDetailsService
    {
        Task DeleteOrderDetailByIdAsync(string orderDetailId, CancellationToken cancellationToken);
        Task<GetOrderDetailsResponseDto> GetOrderDetailByIdAsync(string orderDetailId, CancellationToken cancellationToken);
        Task<CreateOrderDetailsResponseDto> СreateOrderDetailsAsync(CreateOrderDetailsRequestDto orderDetailsRequestDto, CancellationToken cancellationToken);
    }
}