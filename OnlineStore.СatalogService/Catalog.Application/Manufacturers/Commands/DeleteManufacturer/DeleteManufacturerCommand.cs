using MediatR;

namespace Catalog.Application.Manufacturers.Commands.DeleteManufacturer
{
    public class DeleteManufacturerCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}