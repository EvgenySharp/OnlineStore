using Order.Application.Abstractions.Сlasses;
using System.Net;

namespace Order.Application.Exceptions.Order
{
    public class OredrDeleteException : OrderApplicationException
    {
        public override HttpStatusCode StatusCodes { get => HttpStatusCode.BadRequest; }
        public override string Detail { get => "Order failed to delete"; }

        public OredrDeleteException() : base("Order failed to delete") { }
    }
}