using Order.Application.Abstractions.Сlasses;
using System.Net;

namespace Order.Application.Exceptions.OrderDetails
{
    public class OredrDetailDeleteException : OrderApplicationException
    {
        public override HttpStatusCode StatusCodes { get => HttpStatusCode.BadRequest; }
        public override string Detail { get => "Order detail failed to delete"; }

        public OredrDetailDeleteException() : base("Order detail failed to delete") { }
    }
}