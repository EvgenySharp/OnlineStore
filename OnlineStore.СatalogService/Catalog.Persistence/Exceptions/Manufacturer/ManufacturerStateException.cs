using Catalog.Persistence.Abstractions.Classes;

namespace Catalog.Persistence.Exceptions.Manufacturer
{
    public class ManufacturerStateException : RepositoryResultException
    {
        public ManufacturerStateException(string state) : base($"The status should have been \"Added\" but was \"{state}\"") { }
    }
}