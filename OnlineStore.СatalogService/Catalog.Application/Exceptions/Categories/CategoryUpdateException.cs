using Catalog.Application.Abstractions.Сlasses;
using System.Net;

namespace Catalog.Application.Exceptions.Categories
{
    internal class CategoryUpdateException : CatalogApplicationException
    {
        public override HttpStatusCode StatusCodes { get => HttpStatusCode.BadRequest; }
        public override string Detail { get => "Category failed to update"; }

        public CategoryUpdateException() : base("Category failed to update") { }
    }
}