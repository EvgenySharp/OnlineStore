using Order.Application.DTOs.RequestDtos.Orders;
using Order.Application.DTOs.ResponseDtos.Orders;

namespace Order.Application.Abstractions.Interfaces
{
    public interface IOrderService
    {
        Task DeleteOrderByIdAsync(string orderId, CancellationToken cancellationToken);
        Task<IEnumerable<GetOrderResponseDto>> GetOrderPageAsync(int pageSize, int pageCount, CancellationToken cancellationToken);
        Task<GetOrderResponseDto> GetOrderByIdAsync(string orderId, CancellationToken cancellationToken);
        Task<CreateOrderResponseDto> СreateOrderAsync(CreateOrderRequestDto orderRequestDto, CancellationToken cancellationToken);
    }
}