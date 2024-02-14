using Catalog.Domain.Entities;
using Microsoft.AspNetCore.JsonPatch;

namespace Catalog.Persistence.Abstractions.Interfaces
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
        Task<Category?> FindByTitleAsync(string categoryTitle, CancellationToken cancellationToken);
    }
}