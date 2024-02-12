using Catalog.Application.DTOs.RequestDtos.Products;
using MediatR;

namespace Catalog.Application.Products.Commands.UpdateProduct.UpdateManufacturer
{
    public class UpdateProductManufacturerCommand : IRequest
    {
        public UptadeProductManufacturerRequestDto UptadeProductManufacturerRequestDto { get; set; }
    }
}