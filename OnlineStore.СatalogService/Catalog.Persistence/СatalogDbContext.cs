using Catalog.Domain.Entities;
using Catalog.Persistence.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Persistence
{
    public class СatalogDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Product> Products { get; set; }

        public СatalogDbContext(DbContextOptions<СatalogDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CategoryConfiguration());
            builder.ApplyConfiguration(new ManufacturerConfiguration());
            builder.ApplyConfiguration(new ProductConfiguration());
            base.OnModelCreating(builder);
        }
    }
}