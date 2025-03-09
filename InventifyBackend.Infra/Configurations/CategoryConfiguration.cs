using InventifyBackend.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
        }
    }
}
