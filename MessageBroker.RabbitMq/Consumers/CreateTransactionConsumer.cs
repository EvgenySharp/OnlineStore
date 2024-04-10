using MassTransit;
using MessageBroker.RabbitMq.Events;
using Microsoft.Extensions.Logging;

namespace MessageBroker.RabbitMq.Consumers
{
    public class CreateTransactionConsumer : IConsumer<OrderCreateEvent>
    {
        private readonly ILogger<CreateTransactionConsumer> _logger;

        public CreateTransactionConsumer(ILogger<CreateTransactionConsumer> logger)
        {
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<OrderCreateEvent> context)
        {
            _logger.LogInformation($"Consume create order with id = {context.Message.Id}");
            //todo: do something with data
        }
    }
}