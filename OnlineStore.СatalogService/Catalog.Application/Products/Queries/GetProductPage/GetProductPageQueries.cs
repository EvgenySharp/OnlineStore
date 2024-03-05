using Catalog.Application.DTOs.ResponseDtos.Products;
using MediatR;

namespace Catalog.Application.Products.Queries.GetProductList
{
    public class GetProductPageQueries : IRequest<IEnumerable<GetProductResponseDto>>
    {
        public int PageCount { get; set; }
        public int PageSize { get; set; }
        public Guid Categoryid { get; set; }
        public List<Guid> Manufacturerid { get; set; }
    }
}