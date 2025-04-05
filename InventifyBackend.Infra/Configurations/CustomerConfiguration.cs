using InventifyBackend.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventifyBackend.Infra.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");

            builder.HasKey(u => u.Id);
            builder.Property(u => u.Name).HasMaxLength(255).IsRequired();
            builder.Property(u => u.Email).HasMaxLength(255).IsRequired();
            builder.Property(u => u.Phone).HasMaxLength(255).IsRequired();
            builder.Property(u => u.Street).HasMaxLength(255).IsRequired();
            builder.Property(u => u.City).HasMaxLength(255).IsRequired();
            builder.Property(u => u.State).HasMaxLength(255).IsRequired();
            builder.Property(u => u.PostalCode).HasMaxLength(255).IsRequired();
            builder.Property(u => u.AddressNumber).HasMaxLength(255).IsRequired();
            builder.Property(u => u.CreatedAt).HasDefaultValueSql("getdate()").IsRequired();
            builder.Property(u => u.UpdatedAt);

            builder.Property(u => u.UserId).IsRequired();
            builder.HasOne(u => u.User)
                   .WithMany()
                   .HasForeignKey(u => u.UserId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}