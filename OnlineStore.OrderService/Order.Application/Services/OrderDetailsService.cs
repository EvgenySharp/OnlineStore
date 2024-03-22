using AutoMapper;
using Order.Application.Abstractions.Interfaces;
using Order.Application.DTOs.RequestDtos.OrderDetails;
using Order.Application.DTOs.ResponseDtos.OrderDetails;
using Order.Application.Exceptions.OrderDetails;
using Order.Domain.Entities;
using Order.Infrastructure.Abstractions.Interfaces;

namespace Order.Application.Services
{
    public class OrderDetailsService : IOrderDetailsService
    {
        private readonly IMapper _mapper;
        private readonly IOrderDetailsRepository _orderDetailsRepository;

        public OrderDetailsService(
            IMapper mapper,
            IOrderDetailsRepository orderDetailsRepository)
        {
            _mapper = mapper;
            _orderDetailsRepository = orderDetailsRepository;
        }

        public async Task<CreateOrderDetailsResponseDto> СreateOrderDetailsAsync(CreateOrderDetailsRequestDto orderDetailsRequestDto, CancellationToken cancellationToken)
        {
            var orderDetails = _mapper.Map<OrderDetailsEntity>(orderDetailsRequestDto);
            var orderDetailsCreationResult = await _orderDetailsRepository.CreateAsync(orderDetails, cancellationToken);

            if (!orderDetailsCreationResult.Succeeded)
            {
                throw new OrderDetailsCreationException();
            }

            var orderDetailsResponseDto = _mapper.Map<CreateOrderDetailsResponseDto>(orderDetails);

            return orderDetailsResponseDto;
        }

        public async Task<GetOrderDetailsResponseDto> GetOrderDetailByIdAsync(string orderDetailId, CancellationToken cancellationToken)
        {
            var foundOrderDetail = await _orderDetailsRepository.FindByIdAsync(orderDetailId, cancellationToken);

            if (foundOrderDetail is null)
            {
                throw new OrderDetailNotFoundException();
            }

            var orderDetailResponseDto = _mapper.Map<GetOrderDetailsResponseDto>(foundOrderDetail);

            return orderDetailResponseDto;
        }

        public async Task DeleteOrderDetailByIdAsync(string orderDetailId, CancellationToken cancellationToken)
        {
            var foundOrderDetail = await _orderDetailsRepository.FindByIdAsync(orderDetailId, cancellationToken);

            if (foundOrderDetail is null)
            {
                throw new OrderDetailNotFoundException();
            }

            var orderDetailDeleteResult = await _orderDetailsRepository.DeleteAsync(orderDetailId, cancellationToken);

            if (!orderDetailDeleteResult.Succeeded)
            {
                throw new OredrDetailDeleteException();
            }
        }
    }
}