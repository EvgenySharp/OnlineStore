using Catalog.Application.Abstractions.Сlasses;
using System.Net;

namespace Catalog.Application.Exceptions.Manufacturers
{
    public class ManufacturerDeleteException : CatalogApplicationException
    {
        public override HttpStatusCode StatusCodes { get => HttpStatusCode.BadRequest; }
        public override string Detail { get => "Manufacturer failed to delete"; }

        public ManufacturerDeleteException() : base("Manufacturer failed to delete") { }
    }
}