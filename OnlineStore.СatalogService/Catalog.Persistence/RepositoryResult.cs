using Catalog.Persistence.Abstractions.Classes;

namespace Catalog.Persistence
{
    public class RepositoryResult
    {
        public bool Succeeded { get; protected set; }
        public RepositoryResultException Error { get; protected set; }

        public RepositoryResult(
            bool succeeded, 
            RepositoryResultException error = null) 
        {
            Succeeded = succeeded;
            Error = error;
        }
    }
}