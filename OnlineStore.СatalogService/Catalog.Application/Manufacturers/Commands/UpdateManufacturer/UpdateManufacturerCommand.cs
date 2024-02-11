using Catalog.Application.DTOs.RequestDtos.Manufacturers;
using MediatR;

namespace Catalog.Application.Manufacturers.Commands.UpdateBook
{
    public class UpdateManufacturerCommand : IRequest
    {
        public UptadeManufacturerRequestDto uptadeManufacturerRequestDto { get; set; }
    }
}