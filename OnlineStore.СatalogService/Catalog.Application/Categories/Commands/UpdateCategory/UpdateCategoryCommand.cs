using Catalog.Application.DTOs.RequestDtos.Categories;
using MediatR;

namespace Catalog.Application.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommand : IRequest
    {
        public UptadeCategoryRequestDto uptadeCategoryRequestDto { get; set; }
    }
}