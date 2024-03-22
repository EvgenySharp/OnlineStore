using Order.Domain.Entities;

namespace Order.Infrastructure.Abstractions.Interfaces
{
    public interface IOrderRepository : IBaseRepository<OrderEntity>
    {
        Task<IEnumerable<OrderEntity>> GetPageAsync(int pageSize, int pageCount, CancellationToken cancellationToken);
    }
}