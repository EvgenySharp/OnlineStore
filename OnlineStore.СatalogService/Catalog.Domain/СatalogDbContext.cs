using Catalog.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Domain
{
    public class СatalogDbContext : DbContext
    {
        public DbSet<Category> Category { get; set; }
        public DbSet<Manufacturer> Manufacturer { get; set; }
        public DbSet<Product> Product { get; set; }

        public СatalogDbContext(DbContextOptions<СatalogDbContext> options) : base(options) { }
    }
}