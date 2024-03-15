using Catalog.Persistence.Abstractions.Classes;

namespace Catalog.Persistence.Exceptions
{
    public class CategoryStateException : RepositoryResultException
    {
        public CategoryStateException(string state) : base($"The status should have been \"Added\" but was \"{state}\"") { }
    }
}