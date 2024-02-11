using Catalog.Application.Abstractions.Сlasses;
using System.Net;

namespace Catalog.Application.Exceptions.Categories
{
    public class CategoryCreationException : CatalogApplicationException
    {
        public override HttpStatusCode StatusCodes { get => HttpStatusCode.BadRequest; }
        public override string Detail { get => "Category failed to create"; }

        public CategoryCreationException() : base("Category failed to create") { }    
    }
}