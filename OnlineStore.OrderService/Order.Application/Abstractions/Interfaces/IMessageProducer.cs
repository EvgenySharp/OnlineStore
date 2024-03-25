namespace Order.Application.Abstractions.Interfaces
{
    public interface IMessageProducer
    {
        void SendMessage(string message, string routingKey);
    }
}