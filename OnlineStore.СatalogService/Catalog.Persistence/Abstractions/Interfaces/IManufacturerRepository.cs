using Catalog.Domain.Entities;

namespace Catalog.Persistence.Abstractions.Interfaces
{
    public interface IManufacturerRepository
    {
        Task<RepositoryResult> ChangeTitleAsync(Manufacturer manufacturer, string mewTitle);
        Task<RepositoryResult> CreateAsync(Manufacturer manufacturer);
        Task<RepositoryResult> DeleteAsync(Manufacturer manufacturer);
        Task<Manufacturer?> FindByIdAsync(Guid manufacturerId);
        Task<Manufacturer?> FindByTitleAsync(string manufacturerTitle);
        Task<IEnumerable<Manufacturer>> GetAllAsync();
    }
}