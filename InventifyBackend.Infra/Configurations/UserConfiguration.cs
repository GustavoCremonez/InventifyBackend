using InventifyBackend.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventifyBackend.Infra.Configurations
{
    internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(u => u.Id);
            builder.Property(u => u.Name).HasMaxLength(255).IsRequired();
            builder.Property(u => u.Email).HasMaxLength(255).IsRequired();
            builder.Property(u => u.PasswordHash).HasMaxLength(255).IsRequired();
            builder.Property(u => u.PasswordSalt).HasMaxLength(255).IsRequired();
            builder.Property(u => u.CreatedAt).HasDefaultValueSql("getdate()").IsRequired();
            builder.Property(u => u.UpdatedAt);

            builder.HasIndex(u => u.Email);
            
            builder.HasMany(u => u.RefreshTokens)
                .WithOne(rt => rt.User)
                .HasForeignKey(rt => rt.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
