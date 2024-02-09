using Catalog.Application.Abstractions.Сlasses;
using System.Net;

namespace Catalog.Application.Exceptions
{
    public class ManufacturerAlreadyExistsException : CatalogApplicationException
    {
        public override HttpStatusCode StatusCodes { get => HttpStatusCode.Conflict; }
        public override string Detail { get => "Manufacturer with this title already exists"; }

        public ManufacturerAlreadyExistsException() : base("Manufacturer with this title already exists") { }
    }
}