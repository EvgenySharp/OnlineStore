using Catalog.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;

namespace Catalog.Application.Products.Commands.UpdateProduct.UpdateCategory
{
    public class UpdateProductCategoryCommand : IRequest
    {
        public Guid ProductId { get; set; }
        public JsonPatchDocument<Product> JsonPatchProductDto { get; set; }
    }
}