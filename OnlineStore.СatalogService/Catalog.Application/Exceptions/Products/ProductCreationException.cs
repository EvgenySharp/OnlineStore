using Catalog.Application.Abstractions.Сlasses;
using System.Net;

namespace Catalog.Application.Exceptions.Products
{
    public class ProductCreationException : CatalogApplicationException
    {
        public override HttpStatusCode StatusCodes { get => HttpStatusCode.BadRequest; }
        public override string Detail { get => "Product failed to create"; }

        public ProductCreationException() : base("Product failed to create") { }  
    }
}