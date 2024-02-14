using Catalog.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;

namespace Catalog.Application.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommand : IRequest
    {
        public Guid CategoryId { get; set; }
        public JsonPatchDocument<Category> JsonPatchCategoryDto { get; set; }
    }
}