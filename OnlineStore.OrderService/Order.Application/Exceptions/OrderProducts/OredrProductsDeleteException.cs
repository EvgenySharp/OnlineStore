using Order.Application.Abstractions.Сlasses;
using System.Net;

namespace Order.Application.Exceptions.OrderProducts
{
    public class OredrProductsDeleteException : OrderApplicationException
    {
        public override HttpStatusCode StatusCodes { get => HttpStatusCode.BadRequest; }
        public override string Detail { get => "Order products failed to delete"; }

        public OredrProductsDeleteException() : base("Order products failed to delete") { }
    }
}