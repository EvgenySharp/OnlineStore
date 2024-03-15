using Catalog.Application.Abstractions.Сlasses;
using System.Net;

namespace Catalog.Application.Exceptions.Products
{
    public class ProductAlreadyExistsException : CatalogApplicationException
    {
        public override HttpStatusCode StatusCodes { get => HttpStatusCode.Conflict; }
        public override string Detail { get => "Protuct with this title already exists"; }

        public ProductAlreadyExistsException() : base("Product with this title already exists") { }
    }
}