using AutoMapper;
using Catalog.Application.DTOs.ResponseDtos.Products;
using Catalog.Persistence.Abstractions.Interfaces;
using MediatR;

namespace Catalog.Application.Products.Queries.GetProductList
{
    public class GetProductListQueriesHandler : IRequestHandler<GetProductListQueries, IEnumerable<GetProductResponseDto>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductListQueriesHandler(
            IProductRepository productRepository,
            IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetProductResponseDto>> Handle(GetProductListQueries request, CancellationToken cancellationToken)
        {
            var productList = await _productRepository.GetAllAsync(request.PageSize, request.PageCount, cancellationToken);
            var productResponseDtoList = _mapper.Map<List<GetProductResponseDto>>(productList);

            return productResponseDtoList;
        }
    }
}