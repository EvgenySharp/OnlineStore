using Order.Application.Abstractions.Сlasses;
using System.Net;

namespace Order.Application.Exceptions.Order
{
    public class OrderCreationException : OrderApplicationException
    {
        public override HttpStatusCode StatusCodes { get => HttpStatusCode.BadRequest; }
        public override string Detail { get => "Order failed to create"; }

        public OrderCreationException() : base("Order failed to create") { }
    }
}