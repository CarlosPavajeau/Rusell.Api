using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rusell.Routes.Addresses.Domain;
using Rusell.Shared.Extensions;

namespace Rusell.Routes.Shared.Infrastructure.Persistence.EntityConfigurations;

public class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasConversion(v => v.Value, v => AddressId.From(v));

        builder.OwnsOne(x => x.Country)
            .Property(x => x.Value)
            .HasMaxLength(256)
            .HasColumnName(nameof(Address.Country).ToDatabaseFormat());

        builder.OwnsOne(x => x.State)
            .Property(x => x.Value)
            .HasMaxLength(256)
            .HasColumnName(nameof(Address.State).ToDatabaseFormat());

        builder.OwnsOne(x => x.City)
            .Property(x => x.Value)
            .HasMaxLength(256)
            .HasColumnName(nameof(Address.City).ToDatabaseFormat());

        builder.Ignore(x => x.Routes);
    }
}
