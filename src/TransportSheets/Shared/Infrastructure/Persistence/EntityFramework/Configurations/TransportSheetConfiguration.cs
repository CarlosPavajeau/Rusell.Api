using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rusell.Shared.Extensions;
using Rusell.TransportSheets.Domain;

namespace Rusell.TransportSheets.Shared.Infrastructure.Persistence.EntityFramework.Configurations;

public class TransportSheetConfiguration : IEntityTypeConfiguration<TransportSheet>
{
    public void Configure(EntityTypeBuilder<TransportSheet> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasConversion(v => v.Value, v => TransportSheetId.From(v));

        builder.OwnsOne(x => x.Date)
            .Property(x => x.Value)
            .HasColumnName(nameof(TransportSheet.Date).ToDatabaseFormat());

        builder.OwnsOne(x => x.DepartureTime)
            .Property(x => x.Value)
            .HasColumnName(nameof(TransportSheet.DepartureTime).ToDatabaseFormat());

        builder.OwnsOne(x => x.Quota)
            .Property(x => x.Value)
            .HasColumnName(nameof(TransportSheet.Quota).ToDatabaseFormat());

        builder.OwnsOne(x => x.VehicleLicensePlate)
            .Property(x => x.Value)
            .HasColumnName(nameof(TransportSheet.VehicleLicensePlate).ToDatabaseFormat());
        builder.OwnsOne(x => x.VehicleLicensePlate)
            .HasIndex(x => x.Value);

        builder.HasOne(x => x.Dispatcher)
            .WithMany(x => x.TransportSheets)
            .HasForeignKey(x => x.DispatcherId)
            .IsRequired();

        builder.OwnsOne(x => x.CompanyId)
            .Property(x => x.Value)
            .HasColumnName(nameof(TransportSheet.CompanyId).ToDatabaseFormat());
        builder.OwnsOne(x => x.CompanyId)
            .HasIndex(x => x.Value);

        builder.OwnsOne(x => x.RouteId)
            .Property(x => x.Value)
            .HasColumnName(nameof(TransportSheet.RouteId).ToDatabaseFormat());
        builder.OwnsOne(x => x.RouteId)
            .HasIndex(x => x.Value);
    }
}
