using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Auth.DataAccessLayer.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace Auth.DataAccessLayer
{
    public class AuthDbContext : IdentityDbContext<User>
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options) 
        {
            var bdc = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
            if (bdc != null)
            {
                if (!bdc.CanConnect()) bdc.Create();
                if (!bdc.HasTables()) bdc.CreateTables();
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}