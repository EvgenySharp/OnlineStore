using Catalog.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;

namespace Catalog.Application.Products.Commands.UpdateProduct.UpdateTitle
{
    public class UpdateProductTitleCommand : IRequest
    {
        public Guid ProductId { get; set; }
        public JsonPatchDocument<Product> JsonPatchProductDto { get; set; }
    }
}