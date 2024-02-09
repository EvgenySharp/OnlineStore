using System.Net;

namespace Catalog.Application.Abstractions.Сlasses
{
    public abstract class CatalogApplicationException : Exception
    {
        public abstract HttpStatusCode StatusCodes { get; }
        public abstract string Detail { get; }

        public CatalogApplicationException(string message) : base(message) { }
    }
}