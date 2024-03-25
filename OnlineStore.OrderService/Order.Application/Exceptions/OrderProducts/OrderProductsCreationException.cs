using Order.Application.Abstractions.Сlasses;
using System.Net;

namespace Order.Application.Exceptions.OrderProducts
{
    public class OrderProductsCreationException : OrderApplicationException
    {
        public override HttpStatusCode StatusCodes { get => HttpStatusCode.BadRequest; }
        public override string Detail { get => "Order products failed to create"; }

        public OrderProductsCreationException() : base("Order products failed to create") { }
    }
}