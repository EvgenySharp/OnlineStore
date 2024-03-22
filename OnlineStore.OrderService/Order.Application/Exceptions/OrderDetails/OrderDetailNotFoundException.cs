using Order.Application.Abstractions.Сlasses;
using System.Net;

namespace Order.Application.Exceptions.OrderDetails
{
    public class OrderDetailNotFoundException : OrderApplicationException
    {
        public override HttpStatusCode StatusCodes { get => HttpStatusCode.NotFound; }
        public override string Detail { get => "The order detail was not found"; }

        public OrderDetailNotFoundException() : base("Order detail not found") { }
    }
}