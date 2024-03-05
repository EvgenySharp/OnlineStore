using AutoMapper;
using Catalog.Application.DTOs.ResponseDtos.Products;
using Catalog.Persistence.Abstractions.Interfaces;
using MediatR;

namespace Catalog.Application.Products.Queries.GetProductList
{
    public class GetProductPageQueriesHandler : IRequestHandler<GetProductPageQueries, IEnumerable<GetProductResponseDto>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductPageQueriesHandler(
            IProductRepository productRepository,
            IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetProductResponseDto>> Handle(GetProductPageQueries request, CancellationToken cancellationToken)
        {
            var productList = await _productRepository.GetPageAsync(request.PageSize, request.PageCount, request.Categoryid, request.Manufacturerid, cancellationToken);
            var productResponseDtoList = _mapper.Map<List<GetProductResponseDto>>(productList);

            return productResponseDtoList;
        }
    }
}