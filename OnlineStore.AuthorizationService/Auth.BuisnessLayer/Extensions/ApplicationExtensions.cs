using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Auth.BuisnessLayer.Extensions
{
    public static class ApplicationExtensions
    {
        public static IServiceCollection AddValidatorsConfiguration(this IServiceCollection services)
        {
            return services.AddValidatorsFromAssembly(ValidatorsAssemdlyReference.Assembly);
        }
    }
}