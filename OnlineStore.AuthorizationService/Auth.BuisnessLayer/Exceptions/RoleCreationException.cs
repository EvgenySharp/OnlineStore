using Auth.BuisnessLayer.Abstractions.Сlasses;
using System.Net;

namespace Auth.BuisnessLayer.Exceptions
{
    public class RoleCreationException : AuthApplicationException
    {
        public override HttpStatusCode StatusCodes { get => HttpStatusCode.BadRequest; }
        public override string Detail { get => "Role failed to create"; }

        public RoleCreationException() : base("Role failed to create") { }
    }
}