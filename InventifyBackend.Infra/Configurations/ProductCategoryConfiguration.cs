using InventifyBackend.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventifyBackend.Infra.Configurations;

public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
{
    public void Configure(EntityTypeBuilder<ProductCategory> builder)
    {
        builder.ToTable("ProductCategories");

        builder.HasKey(pc => pc.Id);

        builder.Property(pc => pc.ProductId).IsRequired();
        builder.Property(pc => pc.CategoryId).IsRequired();

        builder.HasOne(pc => pc.Product)
               .WithMany()
               .HasForeignKey(pc => pc.ProductId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(pc => pc.Category)
               .WithMany()
               .HasForeignKey(pc => pc.CategoryId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}