using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rusell.Shared.Extensions;
using Rusell.Vehicles.Domain;

namespace Rusell.Vehicles.Shared.Infrastructure.Persistence.EntityConfigurations;

public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
{
    public void Configure(EntityTypeBuilder<Vehicle> builder)
    {
        builder.HasKey(x => x.LicensePlate);

        builder.Property(x => x.LicensePlate)
            .HasConversion(v => v.Value, v => LicensePlate.From(v))
            .HasColumnName(nameof(Vehicle.LicensePlate).ToDatabaseFormat());

        builder.OwnsOne(x => x.InternalNumber)
            .Property(x => x.Value)
            .HasMaxLength(128)
            .HasColumnName(nameof(Vehicle.InternalNumber).ToDatabaseFormat());
        builder.OwnsOne(x => x.InternalNumber)
            .HasIndex(x => x.Value)
            .IsUnique();

        builder.OwnsOne(x => x.PropertyCard)
            .Property(x => x.Value)
            .HasMaxLength(128)
            .HasColumnName(nameof(Vehicle.PropertyCard).ToDatabaseFormat());
        builder.OwnsOne(x => x.PropertyCard)
            .HasIndex(x => x.Value)
            .IsUnique();

        builder.OwnsOne(x => x.Type)
            .Property(x => x.Value)
            .HasMaxLength(128)
            .HasColumnName(nameof(Vehicle.Type).ToDatabaseFormat());

        builder.OwnsOne(x => x.Mark)
            .Property(x => x.Value)
            .HasMaxLength(128)
            .HasColumnName(nameof(Vehicle.Mark).ToDatabaseFormat());

        builder.OwnsOne(x => x.Model)
            .Property(x => x.Value)
            .HasMaxLength(128)
            .HasColumnName(nameof(Vehicle.Model).ToDatabaseFormat());

        builder.OwnsOne(x => x.ModelNumber)
            .Property(x => x.Value)
            .HasMaxLength(128)
            .HasColumnName(nameof(Vehicle.ModelNumber).ToDatabaseFormat());

        builder.OwnsOne(x => x.Color)
            .Property(x => x.Value)
            .HasMaxLength(128)
            .HasColumnName(nameof(Vehicle.Color).ToDatabaseFormat());

        builder.OwnsOne(x => x.Chairs)
            .Property(x => x.Value)
            .HasColumnName(nameof(Vehicle.Chairs).ToDatabaseFormat());

        builder.OwnsOne(x => x.EngineNumber)
            .Property(x => x.Value)
            .HasMaxLength(128)
            .HasColumnName(nameof(Vehicle.EngineNumber).ToDatabaseFormat());
        builder.OwnsOne(x => x.EngineNumber)
            .HasIndex(x => x.Value)
            .IsUnique();

        builder.OwnsOne(x => x.ChassisNumber)
            .Property(x => x.Value)
            .HasMaxLength(128)
            .HasColumnName(nameof(Vehicle.ChassisNumber).ToDatabaseFormat());
        builder.OwnsOne(x => x.ChassisNumber)
            .HasIndex(x => x.Value)
            .IsUnique();

        builder.HasMany(x => x.LegalInformation)
            .WithOne(x => x.Vehicle)
            .HasForeignKey(x => x.VehicleLicensePlate)
            .IsRequired();

        builder.HasOne(x => x.Owner)
            .WithMany(x => x.VehiclesThatOwn)
            .HasForeignKey(x => x.OwnerId)
            .IsRequired();

        builder.HasOne(x => x.Driver)
            .WithMany(x => x.VehiclesThatDrives)
            .HasForeignKey(x => x.DriverId)
            .IsRequired();

        builder.Property(x => x.CompanyId)
            .HasConversion(v => v.Value, v => CompanyId.From(v));

        builder.HasIndex(x => x.CompanyId);
    }
}
