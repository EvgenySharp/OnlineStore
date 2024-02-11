using Catalog.Application.Abstractions.Сlasses;
using System.Net;

namespace Catalog.Application.Exceptions.Categories
{
    public class CategoryAlreadyExistsException : CatalogApplicationException
    {
        public override HttpStatusCode StatusCodes { get => HttpStatusCode.Conflict; }
        public override string Detail { get => "Category with this title already exists"; }

        public CategoryAlreadyExistsException() : base("Category with this title already exists") { }
    }
}