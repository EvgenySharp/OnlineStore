using Catalog.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Domain
{
    public class СatalogDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Product> Products { get; set; }

        public СatalogDbContext(DbContextOptions<СatalogDbContext> options) : base(options) { }
    }
}