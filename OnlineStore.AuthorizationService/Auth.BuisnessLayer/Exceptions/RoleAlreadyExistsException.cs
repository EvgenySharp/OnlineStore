using Auth.BuisnessLayer.Abstractions.Сlasses;
using System.Net;

namespace Auth.BuisnessLayer.Exceptions
{
    public class RoleAlreadyExistsException : AuthApplicationException
    {
        public override HttpStatusCode StatusCodes { get => HttpStatusCode.Conflict; }
        public override string Detail { get => "Role with this name already exists"; }

        public RoleAlreadyExistsException() : base("Role with this name already exists") { }
    }
}