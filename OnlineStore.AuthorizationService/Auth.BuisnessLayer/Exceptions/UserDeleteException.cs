using System.Net;
using Auth.BuisnessLayer.Abstractions.Сlasses;

namespace Auth.BuisnessLayer.Exceptions
{
    public class UserDeleteException : AuthApplicationException
    {
        public override HttpStatusCode StatusCodes { get => HttpStatusCode.BadRequest; }
        public override string Detail { get => "User failed to delete"; }

        public UserDeleteException() : base("User failed to delete") { }
    }
}