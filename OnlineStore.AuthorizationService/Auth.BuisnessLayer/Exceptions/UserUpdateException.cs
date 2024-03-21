using System.Net;
using Auth.BuisnessLayer.Abstractions.Сlasses;

namespace Auth.BuisnessLayer.Exceptions
{
    public class UserUpdateException : AuthApplicationException
    {
        public override HttpStatusCode StatusCodes { get => HttpStatusCode.BadRequest; }
        public override string Detail { get => "User failed to update"; }

        public UserUpdateException() : base("User failed to update") { }
    }
}