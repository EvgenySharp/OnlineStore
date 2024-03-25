using Order.Application.Abstractions.Сlasses;
using System.Net;

namespace Order.Application.Exceptions.Order
{
    public class OrderNotFoundException : OrderApplicationException
    {
        public override HttpStatusCode StatusCodes { get => HttpStatusCode.NotFound; }
        public override string Detail { get => "The order was not found"; }

        public OrderNotFoundException() : base("Order not found") { }
    }
}