using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using InventifyBackend.Domain.Entity;

namespace InventifyBackend.Infra.Configurations;

public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
{
    public void Configure(EntityTypeBuilder<RefreshToken> builder)
    {
        builder.HasKey(rt => rt.Id);

        builder.Property(rt => rt.Token)
            .IsRequired();

        builder.Property(rt => rt.Expires)
            .IsRequired();

        builder.Property(rt => rt.Created)
            .IsRequired();

        builder.Property(rt => rt.CreatedByIp)
            .IsRequired(false);

        builder.Property(rt => rt.Revoked)
            .IsRequired(false);

        builder.Property(rt => rt.RevokedByIp)
            .IsRequired(false);

        builder.Property(rt => rt.ReplacedByToken)
            .IsRequired(false);
        
        builder.Property(rt => rt.UserId)
            .IsRequired();

        builder.HasOne(rt => rt.User)
            .WithMany(u => u.RefreshTokens)  
            .HasForeignKey(rt => rt.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Ignore(rt => rt.IsExpired);
        builder.Ignore(rt => rt.IsActive);

        builder.HasIndex(rt => rt.Token)
            .IsUnique();

        builder.HasIndex(rt => rt.Expires);
    }
}