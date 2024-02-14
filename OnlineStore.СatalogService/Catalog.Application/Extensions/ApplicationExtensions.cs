using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using MediatR;
using Catalog.Application.Validation;
using FluentValidation;


namespace Catalog.Application.Extensions
{
    public static class ApplicationExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }

        public static IServiceCollection AddValidatorsConfiguration(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(ValidatorsAssemdlyReference.Assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            return services;
        }
    }
}