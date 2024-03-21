using Catalog.Application.Abstractions.Сlasses;
using System.Net;

namespace Catalog.Application.Exceptions.Products
{
    public class ProductUpdateException : CatalogApplicationException
    {
        public override HttpStatusCode StatusCodes { get => HttpStatusCode.BadRequest; }
        public override string Detail { get => "Product failed to update"; }

        public ProductUpdateException() : base("Product failed to update") { }
    }
}