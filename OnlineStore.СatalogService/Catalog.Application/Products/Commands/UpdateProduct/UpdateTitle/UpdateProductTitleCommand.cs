using Catalog.Application.DTOs.RequestDtos.Products;
using MediatR;

namespace Catalog.Application.Products.Commands.UpdateProduct.UpdateTitle
{
    public class UpdateProductTitleCommand : IRequest
    {
        public UptadeProductTitleRequestDto UptadeProductTitleRequestDto { get; set; }
    }
}