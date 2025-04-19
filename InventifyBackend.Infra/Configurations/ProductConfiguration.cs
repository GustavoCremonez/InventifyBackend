using InventifyBackend.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventifyBackend.Infra.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");
        
        builder.HasKey(u => u.Id);
        builder.Property(u => u.Name).HasMaxLength(255).IsRequired();
        builder.Property(u => u.Price).HasPrecision(18, 2).IsRequired();
        builder.Property(u => u.Quantity).HasPrecision(18, 2).IsRequired();
        builder.Property(u => u.CreatedAt).HasDefaultValueSql("getdate()").IsRequired();

        builder.Property(u => u.UserId).IsRequired();
        
        builder.HasOne(u => u.User)
            .WithMany()
            .HasForeignKey(u => u.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(p => p.ProductCategories)
            .WithOne(pc => pc.Product)
            .HasForeignKey(pc => pc.ProductId);
    }
}