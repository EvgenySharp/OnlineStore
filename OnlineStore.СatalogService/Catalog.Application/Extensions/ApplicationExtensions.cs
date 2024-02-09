using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using MediatR;
using Catalog.Application.Validation;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

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
            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(RequestDataValidationAttribute));
            });

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.AddValidatorsFromAssembly(ValidatorsAssemdlyReference.Assembly);

            return services;
        }
    }
}