using System.Net;
using Auth.BuisnessLayer.Abstractions.Сlasses;

namespace Auth.BuisnessLayer.Exceptions
{
    public class UserCreationException : AuthApplicationException
    {
        public override HttpStatusCode StatusCodes { get => HttpStatusCode.BadRequest; }
        public override string Detail { get => "User failed to create"; }

        public UserCreationException() : base("User failed to create") { }
    }
}