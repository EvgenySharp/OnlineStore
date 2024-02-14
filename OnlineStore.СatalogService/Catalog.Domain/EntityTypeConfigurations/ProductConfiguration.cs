using Catalog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalog.Domain.EntityTypeConfigurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Title)
                .HasMaxLength(64)
                .IsRequired();

            builder.HasOne(e => e.Category)
               .WithMany(c => c.Products)
               .HasForeignKey(e => e.CategoryId);

            builder.HasOne(e => e.Manufacturer)
               .WithMany()
               .HasForeignKey(e => e.ManufacturerId);
        }
    }
}