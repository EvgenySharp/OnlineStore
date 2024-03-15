using Catalog.Application.DTOs.RequestDtos.Manufacturers;
using Catalog.Application.DTOs.ResponseDtos.Manufacturers;
using MediatR;

namespace Catalog.Application.Manufacturers.Commands.CreateManufacturer
{
    public class CreateManufacturerCommand : IRequest<CreateManufacturerResponseDto>
    {
        public CreateManufacturerRequestDto CreateManufacturerRequestDto { get; set; }
    }
}