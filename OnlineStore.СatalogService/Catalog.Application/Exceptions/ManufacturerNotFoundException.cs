using Catalog.Application.Abstractions.Сlasses;
using System.Net;

namespace Catalog.Application.Exceptions
{
    public class ManufacturerNotFoundException : CatalogApplicationException
    {
        public override HttpStatusCode StatusCodes { get => HttpStatusCode.NotFound; }
        public override string Detail { get => "The manufacturer was not found"; }

        public ManufacturerNotFoundException() : base("Manufacturer not found") { }
    }
}