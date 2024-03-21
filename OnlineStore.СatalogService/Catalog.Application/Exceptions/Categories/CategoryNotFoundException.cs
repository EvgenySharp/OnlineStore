using Catalog.Application.Abstractions.Сlasses;
using System.Net;

namespace Catalog.Application.Exceptions.Categories
{
    public class CategoryNotFoundException : CatalogApplicationException
    {
        public override HttpStatusCode StatusCodes { get => HttpStatusCode.NotFound; }
        public override string Detail { get => "The category was not found"; }

        public CategoryNotFoundException() : base("Category not found") { }
    }
}