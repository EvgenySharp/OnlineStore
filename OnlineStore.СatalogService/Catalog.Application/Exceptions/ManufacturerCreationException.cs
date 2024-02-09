using Catalog.Application.Abstractions.Сlasses;
using System.Net;

namespace Catalog.Application.Exceptions
{
    public class ManufacturerCreationException : CatalogApplicationException
    {
        public override HttpStatusCode StatusCodes { get => HttpStatusCode.BadRequest; }
        public override string Detail { get => "Manufacturer failed to create"; }

        public ManufacturerCreationException() : base("Manufacturer failed to create") { }
    }
}