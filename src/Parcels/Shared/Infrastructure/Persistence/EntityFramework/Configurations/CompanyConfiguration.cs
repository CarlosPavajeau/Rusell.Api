using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rusell.Parcels.Companies.Domain;
using Rusell.Shared.Extensions;

namespace Rusell.Parcels.Shared.Infrastructure.Persistence.EntityFramework.Configurations;

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
    }
}
