using Catalog.Application.DTOs.RequestDtos.Products;
using Catalog.Application.DTOs.ResponseDtos.Products;
using MediatR;

namespace Catalog.Application.Products.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<CreateProtuctResponseDto>
    {
        public CreateProductRequestDto CreateProtuctRequestDto {  get; set; } 
    }
}