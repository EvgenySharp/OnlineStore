using Catalog.Application.DTOs.ResponseDtos;
using MediatR;

namespace Catalog.Application.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler
        : IRequestHandler<CreateProductCommand, CreateProtuctResponseDto>
    {
        public async Task<CreateProtuctResponseDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {

            throw new NotImplementedException();
        }
    }
}