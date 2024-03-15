using Catalog.Application.Abstractions.Сlasses;
using System.Net;

namespace Catalog.Application.Exceptions.Products
{
    public class ProductDeleteException : CatalogApplicationException
    {
        public override HttpStatusCode StatusCodes { get => HttpStatusCode.BadRequest; }
        public override string Detail { get => "Product failed to delete"; }

        public ProductDeleteException() : base("Product failed to delete") { }
    }
}