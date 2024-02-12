using AutoMapper;
using Catalog.Application.DTOs.ResponseDtos.Products;
using Catalog.Application.Exceptions.Products;
using Catalog.Domain.Entities;
using Catalog.Persistence.Abstractions.Interfaces;
using MediatR;

namespace Catalog.Application.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CreateProtuctResponseDto>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(
            IProductRepository productRepository,
            IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<CreateProtuctResponseDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var productRequestDto = request.CreateProtuctRequestDto;
            var foundProduct = await _productRepository.FindByTitleAsync(productRequestDto.Title, cancellationToken);

            if (foundProduct is not null)
            {
                throw new ProductAlreadyExistsException();
            }

            var newProduct = _mapper.Map<Product>(productRequestDto);
            var productCreationResult = await _productRepository.CreateAsync(newProduct, cancellationToken);

            if (!productCreationResult.Succeeded)
            {
                throw new ProductCreationException();
            }

            var productResponseDtos = _mapper.Map<CreateProtuctResponseDto>(newProduct);

            return productResponseDtos;
        }
    }
}