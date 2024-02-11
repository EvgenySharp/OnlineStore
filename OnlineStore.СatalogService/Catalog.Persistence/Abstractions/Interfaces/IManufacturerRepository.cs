using Catalog.Domain.Entities;

namespace Catalog.Persistence.Abstractions.Interfaces
{
    public interface IManufacturerRepository : IBaseRepository<Manufacturer>
    {
        Task<Manufacturer?> FindByTitleAsync(string manufacturerTitle, CancellationToken cancellationToken);
        Task<RepositoryResult> ChangeTitleAsync(Manufacturer manufacturer, string mewTitle, CancellationToken cancellationToken);
    }
}