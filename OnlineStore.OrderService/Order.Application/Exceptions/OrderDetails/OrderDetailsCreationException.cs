using Order.Application.Abstractions.Сlasses;
using System.Net;

namespace Order.Application.Exceptions.OrderDetails
{
    public class OrderDetailsCreationException : OrderApplicationException
    {
        public override HttpStatusCode StatusCodes { get => HttpStatusCode.BadRequest; }
        public override string Detail { get => "Order details failed to create"; }

        public OrderDetailsCreationException() : base("Order details failed to create") { }
    }
}