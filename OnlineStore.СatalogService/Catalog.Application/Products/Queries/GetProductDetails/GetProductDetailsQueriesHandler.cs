using AutoMapper;
using Catalog.Application.DTOs.ResponseDtos.Products;
using Catalog.Application.Exceptions.Products;
using Catalog.Persistence.Abstractions.Interfaces;
using MediatR;

namespace Catalog.Application.Products.Queries.GetProductDetails
{
    public class GetProductDetailsQueriesHandler : IRequestHandler<GetProductDetailsQueries, GetProductResponseDto>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductDetailsQueriesHandler(
            IProductRepository productRepository,
            IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<GetProductResponseDto> Handle(GetProductDetailsQueries request, CancellationToken cancellationToken)
        {
            var foundProduct = await _productRepository.FindByIdAsync(request.Id, cancellationToken);
            
            if (foundProduct is null)
            {
                throw new ProductNotFoundException();
            }

            var productResponseDto = _mapper.Map<GetProductResponseDto>(foundProduct);

            return productResponseDto;
        }
    }
}