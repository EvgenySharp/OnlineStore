using Catalog.Application.DTOs.RequestDtos.Categories;
using Catalog.Application.DTOs.ResponseDtos.Categories;
using MediatR;

namespace Catalog.Application.Categories.Commands.CreateCategories
{
    public class CreateCategoryCommand : IRequest<CreateCategoryResponseDto>
    {
        public CreateCategoryRequestDto CreateCategoryRequestDto { get; set; }
    }
}