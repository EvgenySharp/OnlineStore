using Auth.BuisnessLayer.Abstractions.Сlasses;
using System.Net;

namespace Auth.BuisnessLayer.Exceptions
{
    public class RoleNotFoundException : AuthApplicationException
    {
        public override HttpStatusCode StatusCodes { get => HttpStatusCode.NotFound; }
        public override string Detail { get => "The role was not found"; }

        public RoleNotFoundException() : base("Role not found") { }
    }
}