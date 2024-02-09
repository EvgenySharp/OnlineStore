using Catalog.Application.DTOs.ResponseDtos;
using MediatR;

namespace Catalog.Application.Manufacturers.Commands.CreateManufacturer
{
    public class CreateManufacturerCommand : IRequest<ManufacturerResponseDto>
    {
        public string ManufacturerTitle { get; set; }
    }
}