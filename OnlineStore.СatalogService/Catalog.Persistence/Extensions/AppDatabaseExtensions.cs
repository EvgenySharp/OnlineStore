using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Catalog.Persistence.Extensions
{
    public static class AppDatabaseExtensions
    {
        public static IServiceCollection ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<СatalogDbContext>(options =>
                options.UseSqlServer(connectionString, dbContext => dbContext.MigrationsAssembly("Catalog.Persistence")));

            return services;
        }
    }
}