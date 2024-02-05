using Auth.DataAccessLayer.Enums;
using Microsoft.AspNetCore.Identity;

namespace Auth.DataAccessLayer.Entity
{
    public class User : IdentityUser
    {
        public Roles Role { get; set; }
    }
}