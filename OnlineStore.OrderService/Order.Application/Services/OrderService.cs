using AutoMapper;
using Order.Domain.Entities;
using Order.Application.Abstractions.Interfaces;
using Order.Application.DTOs.RequestDtos.Orders;
using Order.Application.DTOs.ResponseDtos.Orders;
using Order.Infrastructure.Abstractions.Interfaces;
using Order.Application.DTOs.RequestDtos.OrderDetails;
using Order.Application.DTOs.RequestDtos.OrderProducts;
using Order.Application.Exceptions.Order;

namespace Order.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderDetailsService _orderDetailsService;
        private readonly IOrderProductsService _orderProductsService;

        public OrderService(
            IMapper mapper,
            IOrderRepository orderRepository,
            IOrderDetailsService orderDetailsService,
            IOrderProductsService orderProductsService)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
            _orderDetailsService = orderDetailsService;
            _orderProductsService = orderProductsService;
        }

        public async Task<CreateOrderResponseDto> СreateOrderAsync(CreateOrderRequestDto orderRequestDto, CancellationToken cancellationToken)
        {
            var orderProductsRequestDto = _mapper.Map<CreateOrderProductsRequestDto>(orderRequestDto);
            var orderProductsResponseDto = await _orderProductsService.СreateOrderProductsAsync(orderProductsRequestDto, cancellationToken);

            var orderDetailsRequestDto = _mapper.Map<CreateOrderDetailsRequestDto>(orderRequestDto);
            orderDetailsRequestDto.IdOrderProducts = orderProductsResponseDto.Id;
            var orderDetailsResponseDto = await _orderDetailsService.СreateOrderDetailsAsync(orderDetailsRequestDto, cancellationToken);

            var orderEntity = _mapper.Map<OrderEntity>(orderDetailsResponseDto);
            var orderCreationResult = await _orderRepository.CreateAsync(orderEntity, cancellationToken);

            if (!orderCreationResult.Succeeded)
            {
                throw new OrderCreationException();
            }

            var orderResponseDto = _mapper.Map<CreateOrderResponseDto>(orderEntity);

            return orderResponseDto;
        }

        public async Task<IEnumerable<GetOrderResponseDto>> GetOrderPageAsync(int pageSize, int pageCount, CancellationToken cancellationToken)
        {
            var orderList = await _orderRepository.GetPageAsync(pageSize, pageCount, cancellationToken);
            var orderResponseDtoList = _mapper.Map<List<GetOrderResponseDto>>(orderList);

            return orderResponseDtoList;
        }

        public async Task<GetOrderResponseDto> GetOrderByIdAsync(string orderId, CancellationToken cancellationToken)
        {
            var foundOrder = await _orderRepository.FindByIdAsync(orderId, cancellationToken);

            if (foundOrder is null)
            {
                throw new OrderNotFoundException();
            }

            var orderResponseDto = _mapper.Map<GetOrderResponseDto>(foundOrder);

            return orderResponseDto;
        }

        public async Task DeleteOrderByIdAsync(string orderId, CancellationToken cancellationToken)
        {
            var foundOrder = await _orderRepository.FindByIdAsync(orderId, cancellationToken);

            if (foundOrder is null)
            {
                throw new OrderNotFoundException();
            }

            var orderDeleteResult = await _orderRepository.DeleteAsync(orderId, cancellationToken);

            if (!orderDeleteResult.Succeeded)
            {
                throw new OredrDeleteException();
            }
        }
    }
}