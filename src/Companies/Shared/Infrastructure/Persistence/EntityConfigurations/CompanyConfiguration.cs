using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rusell.Companies.Domain;
using Rusell.Shared.Extensions;

namespace Rusell.Companies.Shared.Infrastructure.Persistence.EntityConfigurations;

public class CompanyConfiguration : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasConversion(v => v.Value, v => CompanyId.From(v));

        builder.OwnsOne(x => x.Name)
            .Property(x => x.Value)
            .HasMaxLength(256)
            .HasColumnName(nameof(Company.Name).ToDatabaseFormat());

        builder.OwnsOne(x => x.Nit)
            .Property(x => x.Value)
            .HasMaxLength(256)
            .HasColumnName(nameof(Company.Nit).ToDatabaseFormat());

        builder.OwnsOne(x => x.Nit)
            .HasIndex(x => x.Value)
            .IsUnique();

        builder.OwnsOne(x => x.Info)
            .Property(x => x.Value)
            .HasMaxLength(256)
            .HasColumnName(nameof(Company.Info).ToDatabaseFormat());

        builder.OwnsOne(x => x.UserId)
            .Property(x => x.Value)
            .HasMaxLength(256)
            .HasColumnName(nameof(Company.UserId).ToDatabaseFormat());

        builder.OwnsOne(x => x.UserId)
            .HasIndex(x => x.Value);
    }
}