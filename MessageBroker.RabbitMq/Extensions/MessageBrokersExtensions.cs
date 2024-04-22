using MassTransit;
using MessageBroker.RabbitMq.Consumers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MessageBroker.RabbitMq.Extensions
{
    public static class MessageBrokersExtensions
    {
        public static IServiceCollection AddMessageBrokers(this IServiceCollection services, IConfiguration configuration)
        {
            return services.AddMassTransit(x =>
            {
                x.AddConsumer<CreateTransactionConsumer>();

                x.UsingRabbitMq((context, configurator) =>
                {
                    configurator.Host(configuration["MessageBroker:Host"], h =>
                    {
                        h.Username(configuration["MessageBroker:Username"]);
                        h.Password(configuration["MessageBroker:Password"]);
                    });

                    configurator.ReceiveEndpoint("CreateTransactionsQueue", e =>
                    {
                        e.ConfigureConsumer<CreateTransactionConsumer>(context);
                    });

                    configurator.ClearSerialization();
                    configurator.UseRawJsonSerializer();
                    configurator.ConfigureEndpoints(context);
                });
            });
        }
    }
}