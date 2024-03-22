using Order.Domain.Entities;

namespace Order.Infrastructure.Abstractions.Interfaces
{
    public interface IOrderProductsRepository : IBaseRepository<OrderProductsEntity>
    {
    }
}