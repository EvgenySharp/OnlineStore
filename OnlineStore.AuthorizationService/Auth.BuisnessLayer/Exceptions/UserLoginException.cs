using System.Net;
using Auth.BuisnessLayer.Abstractions.Сlasses;

namespace Auth.BuisnessLayer.Exceptions
{
    public class UserLoginException : AuthApplicationException
    {
        public override HttpStatusCode StatusCodes { get => HttpStatusCode.BadRequest; }
        public override string Detail { get => "The user's authorization failed with an error"; }

        public UserLoginException() : base("User failed to login") { }
    }
}