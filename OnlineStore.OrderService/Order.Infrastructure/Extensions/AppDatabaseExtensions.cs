
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Order.Infrastructure.Options;

namespace Order.Infrastructure.Extensions
{
    public static class AppDatabaseExtensions
    {
        public static IServiceCollection ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<OrderStoreDatabaseSettings>(
                (settings) => configuration.GetSection("OrderStoreDatabase").Bind(settings));

            return services;            
        }
    }
}
