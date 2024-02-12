using Catalog.Domain.Entities;

namespace Catalog.Persistence.Abstractions.Interfaces
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task<Product?> FindByTitleAsync(string productTitle, CancellationToken cancellationToken);
        Task<RepositoryResult> ChangeTitleAsync(Product product, string newTitle, CancellationToken cancellationToken);
        Task<RepositoryResult> ChangeCategoryIdAsync(Product product, Guid newCategoryId, CancellationToken cancellationToken);
        Task<RepositoryResult> ChangeManufacturerIdAsync(Product product, Guid newManufacturerId, CancellationToken cancellationToken);
    }
}