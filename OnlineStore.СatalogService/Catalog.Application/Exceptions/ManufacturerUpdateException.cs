using Catalog.Application.Abstractions.Сlasses;
using System.Net;

namespace Catalog.Application.Exceptions
{
    public class ManufacturerUpdateException : CatalogApplicationException
    {
        public override HttpStatusCode StatusCodes { get => HttpStatusCode.BadRequest; }
        public override string Detail { get => "Manufacturer failed to update"; }

        public ManufacturerUpdateException() : base("Manufacturer failed to update") { }
    }
}