using System.Net;

namespace Order.Application.Abstractions.Сlasses
{
    abstract public class OrderApplicationException : Exception
    {
        public abstract HttpStatusCode StatusCodes { get; }
        public abstract string Detail { get; }

        public OrderApplicationException(string message) : base(message) { }
    }
}