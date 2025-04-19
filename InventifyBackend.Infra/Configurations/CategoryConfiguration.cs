using InventifyBackend.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text.Json;

namespace InventifyBackend.Infra.Configurations
{
    internal sealed class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");

            builder.HasKey(u => u.Id);
            builder.Property(u => u.Name).HasMaxLength(255).IsRequired();
            builder.Property(u => u.Description).HasMaxLength(500).IsRequired();
            builder.Property(u => u.CreatedAt).HasDefaultValueSql("getdate()").IsRequired();
            builder.Property(u => u.UpdatedAt);

            builder.Property(u => u.ProductCategories)
                   .HasConversion(
                       v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
                       v => JsonSerializer.Deserialize<List<ProductCategory>>(v, (JsonSerializerOptions)null))
                   .HasColumnType("nvarchar(max)");
        }
    }
}