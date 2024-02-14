using Catalog.Domain.Entities;
using Microsoft.AspNetCore.JsonPatch;

namespace Catalog.Persistence.Abstractions.Interfaces
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task<Product?> FindByTitleAsync(string productTitle, CancellationToken cancellationToken);
    }
}