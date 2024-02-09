using Catalog.Application.DTOs.ResponseDtos;
using MediatR;

namespace Catalog.Application.Products.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<CreateProtuctResponseDto>
    {
        public string ProductTitle { get; set; }
        public ManufacturerResponseDto Manufacturer { get; set; }
        public CreateCategoryResponseDto Category { get; set; }
    }
}