using Catalog.Domain.Entities;
using Microsoft.AspNetCore.JsonPatch;

namespace Catalog.Persistence.Abstractions.Interfaces
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task<IEnumerable<Product>> GetPageAsync(int pageSize, int pageNumber, Guid categoryId, List<Guid> manufacturerIds, CancellationToken cancellationToken);
        Task<Product?> FindByTitleAsync(string productTitle, CancellationToken cancellationToken);
    }
}