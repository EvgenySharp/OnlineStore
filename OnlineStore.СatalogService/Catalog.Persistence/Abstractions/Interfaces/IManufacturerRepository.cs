using Catalog.Domain.Entities;

namespace Catalog.Persistence.Abstractions.Interfaces
{
    public interface IManufacturerRepository : IBaseRepository<Manufacturer>
    {
        Task<IEnumerable<Manufacturer>> GetPageAsync(int pageSize, int pageNumber, CancellationToken cancellationToken);
        Task<Manufacturer?> FindByTitleAsync(string manufacturerTitle, CancellationToken cancellationToken);
    }
}