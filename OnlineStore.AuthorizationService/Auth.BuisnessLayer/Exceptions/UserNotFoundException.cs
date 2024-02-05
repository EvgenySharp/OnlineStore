using System.Net;
using Auth.BuisnessLayer.Abstractions.Сlasses;

namespace Auth.BuisnessLayer.Exceptions
{
    public class UserNotFoundException : AuthApplicationException
    {
        public override HttpStatusCode StatusCodes { get => HttpStatusCode.NotFound; }
        public override string Detail { get => "The user was not found"; }

        public UserNotFoundException() : base("User not found") { }        
    }
}