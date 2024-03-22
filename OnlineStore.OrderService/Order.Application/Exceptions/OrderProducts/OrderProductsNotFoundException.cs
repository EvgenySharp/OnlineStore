using Order.Application.Abstractions.Сlasses;
using System.Net;

namespace Order.Application.Exceptions.OrderProducts
{
    public class OrderProductsNotFoundException : OrderApplicationException
    {
        public override HttpStatusCode StatusCodes { get => HttpStatusCode.NotFound; }
        public override string Detail { get => "The order products was not found"; }

        public OrderProductsNotFoundException() : base("Order products not found") { }
    }
}