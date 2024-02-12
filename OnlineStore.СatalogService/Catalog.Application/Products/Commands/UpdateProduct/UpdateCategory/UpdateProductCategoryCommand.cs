using Catalog.Application.DTOs.RequestDtos.Products;
using MediatR;

namespace Catalog.Application.Products.Commands.UpdateProduct.UpdateCategory
{
    public class UpdateProductCategoryCommand : IRequest
    {
        public UptadeProductCategoryRequestDto UptadeProductCategoryRequestDto { get; set; }
    }
}