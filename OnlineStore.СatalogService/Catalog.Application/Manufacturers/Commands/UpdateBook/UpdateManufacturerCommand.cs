using Catalog.Application.DTOs.ResponseDtos;
using MediatR;

namespace Catalog.Application.Manufacturers.Commands.UpdateBook
{
    public class UpdateManufacturerCommand : IRequest
    {
        public string Title { get; set; }
    }
}