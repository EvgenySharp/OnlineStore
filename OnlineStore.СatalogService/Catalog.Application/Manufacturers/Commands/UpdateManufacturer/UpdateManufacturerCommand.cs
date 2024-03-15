using Catalog.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;

namespace Catalog.Application.Manufacturers.Commands.UpdateBook
{
    public class UpdateManufacturerCommand : IRequest
    {
        public Guid ManufacturerId { get; set; }
        public JsonPatchDocument<Manufacturer> JsonPatchManufacturerDto { get; set; }
    }
}