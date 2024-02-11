using Catalog.Application.DTOs.ResponseDtos.Categories;
using Catalog.Application.DTOs.ResponseDtos.Manufacturers;
using Catalog.Application.DTOs.ResponseDtos.Products;
using MediatR;

namespace Catalog.Application.Products.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<CreateProtuctResponseDto>
    {
        public string ProductTitle { get; set; }
        public CreateManufacturerResponseDto Manufacturer { get; set; }
        public CreateCategoryResponseDto Category { get; set; }
    }
}