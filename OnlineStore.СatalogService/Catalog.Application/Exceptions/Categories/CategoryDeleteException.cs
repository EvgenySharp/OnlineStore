using Catalog.Application.Abstractions.Сlasses;
using System.Net;

namespace Catalog.Application.Exceptions.Categories
{
    public class CategoryDeleteException : CatalogApplicationException
    {
        public override HttpStatusCode StatusCodes { get => HttpStatusCode.BadRequest; }
        public override string Detail { get => "Category failed to delete"; }

        public CategoryDeleteException() : base("Category failed to delete") { }
    }
}