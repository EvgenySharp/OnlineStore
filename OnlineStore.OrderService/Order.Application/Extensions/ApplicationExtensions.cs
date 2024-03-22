using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Order.Application.Abstractions.Interfaces;
using Order.Application.Services;
using Order.Application.Validation;

namespace Order.Application.Extensions
{
    public static class ApplicationExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            return services
                .AddScoped<IOrderService, OrderService>()
                .AddScoped<IOrderDetailsService, OrderDetailsService>()
                .AddScoped<IOrderProductsService, OrderProductsService>();
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