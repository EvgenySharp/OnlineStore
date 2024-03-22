using Order.Application.DTOs.RequestDtos.OrderProducts;
using Order.Application.DTOs.ResponseDtos.OrderProducts;

namespace Order.Application.Abstractions.Interfaces
{
    public interface IOrderProductsService
    {
        Task DeleteOrderProductsByIdAsync(string orderProductsId, CancellationToken cancellationToken);
        Task<GetOrderProductsResponseDto> GetOrderProductsByIdAsync(string orderProductsId, CancellationToken cancellationToken);
        Task<CreateOrderProductsResponseDto> СreateOrderProductsAsync(CreateOrderProductsRequestDto orderProductsRequestDto, CancellationToken cancellationToken);
    }
}