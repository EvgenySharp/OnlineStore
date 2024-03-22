using Order.Infrastructure.Abstractions.Classes;

namespace Order.Infrastructure.Exceptions
{
    public class TaskCompletedExceptions : RepositoryResultException
    {
        public TaskCompletedExceptions(string state) : base($"The status \"{state}\"") { }
    }
}