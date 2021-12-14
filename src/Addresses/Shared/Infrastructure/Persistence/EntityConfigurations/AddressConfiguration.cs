using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rusell.Addresses.Domain;
using Rusell.Shared.Extensions;

namespace Rusell.Addresses.Shared.Infrastructure.Persistence.EntityConfigurations;

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

        builder.OwnsOne(x => x.Neighborhood)
            .Property(x => x.Value)
            .HasMaxLength(256)
            .HasColumnName(nameof(Address.Neighborhood).ToDatabaseFormat());

        builder.OwnsOne(x => x.StreetName)
            .Property(x => x.Value)
            .HasMaxLength(256)
            .HasColumnName(nameof(Address.StreetName).ToDatabaseFormat());

        builder.OwnsOne(x => x.Intersection)
            .Property(x => x.Value)
            .HasMaxLength(256)
            .HasColumnName(nameof(Address.Intersection).ToDatabaseFormat());

        builder.OwnsOne(x => x.StreetNumber)
            .Property(x => x.Value)
            .HasMaxLength(256)
            .HasColumnName(nameof(Address.StreetNumber).ToDatabaseFormat());

        builder.OwnsOne(x => x.Comments)
            .Property(x => x.Value)
            .HasMaxLength(256)
            .HasColumnName(nameof(Address.Comments).ToDatabaseFormat());

        builder.OwnsOne(x => x.UserId)
            .Property(x => x.Value)
            .HasMaxLength(256)
            .HasColumnName(nameof(Address.UserId).ToDatabaseFormat());

        builder.OwnsOne(x => x.UserId)
            .HasIndex(x => x.Value);
    }
}