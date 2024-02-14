using Catalog.Application.DTOs.RequestDtos.Products;
using Catalog.Application.DTOs.ResponseDtos.Products;
using MediatR;

namespace Catalog.Application.Products.Queries.GetProductList
{
    public class GetProductListQueries : IRequest<IEnumerable<GetProductResponseDto>>
    {
        public int PageCount { get; set; }
        public int PageSize { get; set; }
    }
}