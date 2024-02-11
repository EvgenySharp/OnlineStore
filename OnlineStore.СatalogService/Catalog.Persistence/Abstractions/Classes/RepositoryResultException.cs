namespace Catalog.Persistence.Abstractions.Classes
{
    public abstract class RepositoryResultException : Exception
    {
        public RepositoryResultException(string message) : base(message) { }
    }
}