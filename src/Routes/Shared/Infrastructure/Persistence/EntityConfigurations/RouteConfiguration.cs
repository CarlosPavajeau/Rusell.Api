using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rusell.Routes.Domain;
using Rusell.Shared.Extensions;

namespace Rusell.Routes.Shared.Infrastructure.Persistence.EntityConfigurations;

public class RouteConfiguration : IEntityTypeConfiguration<Route>
{
    public void Configure(EntityTypeBuilder<Route> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasConversion(v => v.Value, v => RouteId.From(v));

        builder.OwnsOne(x => x.From)
            .Property(x => x.Value)
            .HasColumnName(nameof(Route.From).ToDatabaseFormat());

        builder.OwnsOne(x => x.To)
            .Property(x => x.Value)
            .HasColumnName(nameof(Route.To).ToDatabaseFormat());

        builder.OwnsOne(x => x.Cost)
            .Property(x => x.Value)
            .HasPrecision(12, 2)
            .HasColumnName(nameof(Route.Cost).ToDatabaseFormat());

        builder.OwnsOne(x => x.IsCustomerPickedUpAtHome)
            .Property(x => x.Value)
            .HasColumnName(nameof(Route.IsCustomerPickedUpAtHome).ToDatabaseFormat());

        builder.OwnsOne(x => x.IsCustomerDroppedOffAtHome)
            .Property(x => x.Value)
            .HasColumnName(nameof(Route.IsCustomerDroppedOffAtHome).ToDatabaseFormat());

        builder.HasOne(x => x.Company)
            .WithMany(x => x.Routes)
            .HasForeignKey(x => x.CompanyId)
            .IsRequired();
    }
}
