using Catalog.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;

namespace Catalog.Application.Products.Commands.UpdateProduct.UpdateManufacturer
{
    public class UpdateProductManufacturerCommand : IRequest
    {
        public Guid ProductId { get; set; }
        public JsonPatchDocument<Product> JsonPatchProductDto { get; set; }
    }
}