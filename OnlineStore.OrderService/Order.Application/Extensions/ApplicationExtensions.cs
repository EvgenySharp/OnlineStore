using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Order.Application.Abstractions.Interfaces;
using Order.Application.Options;
using Order.Application.Services;
using Order.Application.Validation;
using Order.Infrastructure.Options;
using RabbitMQ.Client;

namespace Order.Application.Extensions
{
    public static class ApplicationExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            return services
                .AddScoped<IOrderService, OrderService>()
                .AddScoped<IOrderDetailsService, OrderDetailsService>()
                .AddScoped<IOrderProductsService, OrderProductsService>()
                .AddScoped<IMessageBrokerSecvice, MessageBrokerSecvice>();
        }

        public static IServiceCollection AddRabbitMQSettings(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<RabbitMQSettings>(configuration.GetSection("RabbitMQSettings"));

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