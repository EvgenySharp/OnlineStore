using System.Net;
using Auth.BuisnessLayer.Abstractions.Сlasses;

namespace Auth.BuisnessLayer.Exceptions
{
    public class UserAlreadyExistsException : AuthApplicationException
    {
        public override HttpStatusCode StatusCodes { get => HttpStatusCode.Conflict; }
        public override string Detail { get => "User with this login already exists"; }

        public UserAlreadyExistsException() : base("User with this login already exists") { }
    }
}