using Catalog.Persistence.Abstractions.Interfaces;
using Catalog.Persistence.Repositores;
using Microsoft.Extensions.DependencyInjection;

namespace Catalog.Persistence.Extensions
{
    public static class PersistenceExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services
                .AddScoped<IManufacturerRepository, ManufacturerRepository>()
                .AddScoped<ICategoryRepository, CategoryRepository>()
                .AddScoped<IProductRepository, ProductRepository>();
        }
    }
}