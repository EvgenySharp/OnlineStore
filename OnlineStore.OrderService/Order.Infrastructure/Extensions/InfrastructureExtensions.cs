using Microsoft.Extensions.DependencyInjection;
using Order.Infrastructure.Abstractions.Interfaces;
using Order.Infrastructure.Repositores;

namespace Order.Infrastructure.Extensions
{
    public static class PersistenceExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services
                .AddScoped<IOrderDetailsRepository, OrderDetailsRepository>()
                .AddScoped<IOrderProductsRepository, OrderProductsRepository>()
                .AddScoped<IOrderRepository, OrderRepository>();
        }
    }
}
