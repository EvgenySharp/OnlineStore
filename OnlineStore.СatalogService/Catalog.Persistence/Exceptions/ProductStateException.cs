using Catalog.Persistence.Abstractions.Classes;

namespace Catalog.Persistence.Exceptions
{
    public class ProductStateException : RepositoryResultException
    {
        public ProductStateException(string state) : base($"The status should have been \"Added\" but was \"{state}\"") { }
    }
}