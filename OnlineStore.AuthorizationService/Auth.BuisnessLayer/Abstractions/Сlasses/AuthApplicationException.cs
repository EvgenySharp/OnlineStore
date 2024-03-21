using System.Net;

namespace Auth.BuisnessLayer.Abstractions.Сlasses
{
    abstract public class AuthApplicationException : Exception
    {
        public abstract HttpStatusCode StatusCodes { get;}
        public abstract string Detail { get; }

        public AuthApplicationException(string message) : base(message) { }
    }
}