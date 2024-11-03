// QRMenu.Infrastructure/Persistence/Configurations/BranchConfiguration.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QRMenu.Domain.Entities;

namespace QRMenu.Infrastructure.Persistence.Configurations;

public class BranchConfiguration : IEntityTypeConfiguration<Branch>
{
    public void Configure(EntityTypeBuilder<Branch> builder)
    {
        builder.Property(b => b.Name)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(b => b.Code)
            .IsRequired()
            .HasMaxLength(50);

        // CompanyId ve Code birlikte unique olmalı
        builder.HasIndex(b => new { b.CompanyId, b.Code })
            .IsUnique();
    }
}