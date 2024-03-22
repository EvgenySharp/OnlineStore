using Order.Infrastructure.Abstractions.Classes;

namespace Order.Infrastructure
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