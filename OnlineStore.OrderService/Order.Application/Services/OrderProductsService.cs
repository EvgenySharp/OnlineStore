using AutoMapper;
using Order.Application.Abstractions.Interfaces;
using Order.Application.DTOs.RequestDtos.OrderProducts;
using Order.Application.DTOs.ResponseDtos.OrderProducts;
using Order.Application.Exceptions.OrderProducts;
using Order.Domain.Entities;
using Order.Infrastructure.Abstractions.Interfaces;

namespace Order.Application.Services
{
    public class OrderProductsService : IOrderProductsService
    {
        private readonly IMapper _mapper;
        private readonly IOrderProductsRepository _orderProductsRepository;

        public OrderProductsService(
            IMapper mapper,
            IOrderProductsRepository orderProductsRepository)
        {
            _mapper = mapper;
            _orderProductsRepository = orderProductsRepository;
        }

        public async Task<CreateOrderProductsResponseDto> СreateOrderProductsAsync(CreateOrderProductsRequestDto orderProductsRequestDto, CancellationToken cancellationToken)
        {
            var orderProducts = _mapper.Map<OrderProductsEntity>(orderProductsRequestDto);
            var orderProductsCreationResult = await _orderProductsRepository.CreateAsync(orderProducts, cancellationToken);

            if (!orderProductsCreationResult.Succeeded)
            {
                throw new OrderProductsCreationException();
            }

            var orderProductsResponseDto = _mapper.Map<CreateOrderProductsResponseDto>(orderProducts);

            return orderProductsResponseDto;
        }

        public async Task<GetOrderProductsResponseDto> GetOrderProductsByIdAsync(string orderProductsId, CancellationToken cancellationToken)
        {
            var foundOrderProducts = await _orderProductsRepository.FindByIdAsync(orderProductsId, cancellationToken);

            if (foundOrderProducts is null)
            {
                throw new OrderProductsNotFoundException();
            }

            var orderProductsResponseDto = _mapper.Map<GetOrderProductsResponseDto>(foundOrderProducts);

            return orderProductsResponseDto;
        }

        public async Task DeleteOrderProductsByIdAsync(string orderProductsId, CancellationToken cancellationToken)
        {
            var foundOrderProducts = await _orderProductsRepository.FindByIdAsync(orderProductsId, cancellationToken);

            if (foundOrderProducts is null)
            {
                throw new OrderProductsNotFoundException();
            }

            var orderProductsDeleteResult = await _orderProductsRepository.DeleteAsync(orderProductsId, cancellationToken);

            if (!orderProductsDeleteResult.Succeeded)
            {
                throw new OredrProductsDeleteException();
            }
        }
    }
}