using Catalog.Application.DTOs.ResponseDtos.Products;
using MediatR;

namespace Catalog.Application.Products.Queries.GetProductDetails
{
    public class GetProductDetailsQueries : IRequest<GetProductResponseDto>
    {
        public Guid Id { get; set; }
    }
}