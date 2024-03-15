using Catalog.Application.Abstractions.Сlasses;
using System.Net;

namespace Catalog.Application.Exceptions.Products
{
    public class ProductNotFoundException : CatalogApplicationException
    {
        public override HttpStatusCode StatusCodes { get => HttpStatusCode.NotFound; }
        public override string Detail { get => "The product was not found"; }

        public ProductNotFoundException() : base("Product not found") { }
    }
}