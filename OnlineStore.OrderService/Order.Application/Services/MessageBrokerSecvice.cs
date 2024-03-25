using Microsoft.Extensions.Options;
using Order.Application.Abstractions.Interfaces;
using Order.Application.Options;
using RabbitMQ.Client;
using System.Text;

namespace Order.Application.Services
{
    public class MessageBrokerSecvice : IMessageBrokerSecvice
    {
        private readonly ConnectionFactory _factory;
        private readonly IOptions<RabbitMQSettings> _rabbitMQSettings;

        public MessageBrokerSecvice(IOptions<RabbitMQSettings> rabbitMQSettings) 
        {
            _rabbitMQSettings = rabbitMQSettings;
            _factory = new ConnectionFactory() { HostName = _rabbitMQSettings.Value.HostName };
        }

        public void SendMessage(string message, string routingKey)
        {
            using (var connection = _factory.CreateConnection()) 
            {
                using (var channel = connection.CreateModel())
                {
                    channel.ExchangeDeclare(
                        exchange: _rabbitMQSettings.Value.Exchange, 
                        type: ExchangeType.Direct);

                    var body = Encoding.UTF8.GetBytes(message);

                    channel.BasicPublish(
                        exchange: _rabbitMQSettings.Value.Exchange,
                        routingKey: routingKey,
                        basicProperties: null,
                        body: body);
                }
            }
        }
    }
}