namespace Order.Infrastructure.Abstractions.Classes
{
    public abstract class RepositoryResultException : Exception
    {
        public RepositoryResultException(string message) : base(message) { }
    }
}