using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rusell.Parcels.Domain;
using Rusell.Shared.Extensions;

namespace Rusell.Parcels.Shared.Infrastructure.Persistence.EntityFramework.Configurations;

public class ParcelConfiguration : IEntityTypeConfiguration<Parcel>
{
    public void Configure(EntityTypeBuilder<Parcel> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasConversion(v => v.Value, v => ParcelId.From(v));

        builder.OwnsOne(x => x.Date)
            .Property(x => x.Value)
            .HasColumnName(nameof(Parcel.Date).ToDatabaseFormat());

        builder.OwnsOne(x => x.Description)
            .Property(x => x.Value)
            .HasColumnName(nameof(Parcel.Description).ToDatabaseFormat());

        builder.OwnsOne(x => x.Cost)
            .Property(x => x.Value)
            .HasColumnName(nameof(Parcel.Cost).ToDatabaseFormat());

        builder.Property(x => x.State)
            .HasConversion(
                v => v.ToString(),
                v => (ParcelState) Enum.Parse(typeof(ParcelState), v))
            .HasMaxLength(64);

        builder.OwnsOne(x => x.VehicleLicensePlate)
            .Property(x => x.Value)
            .HasColumnName(nameof(Parcel.VehicleLicensePlate).ToDatabaseFormat());
        builder.OwnsOne(x => x.VehicleLicensePlate)
            .HasIndex(x => x.Value);

        builder.HasOne(x => x.Dispatcher)
            .WithMany(x => x.Parcels)
            .HasForeignKey(x => x.DispatcherId)
            .IsRequired();

        builder.HasOne(x => x.Sender)
            .WithMany(x => x.ParcelsSent)
            .HasForeignKey(x => x.SenderId)
            .IsRequired();

        builder.HasOne(x => x.Receiver)
            .WithMany(x => x.ParcelsReceived)
            .HasForeignKey(x => x.ReceiverId)
            .IsRequired();

        builder.HasOne(x => x.Company)
            .WithMany(x => x.Parcels)
            .HasForeignKey(x => x.CompanyId)
            .IsRequired();
    }
}
