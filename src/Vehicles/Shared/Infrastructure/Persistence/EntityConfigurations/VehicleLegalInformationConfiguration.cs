using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rusell.Shared.Extensions;
using Rusell.Vehicles.Domain.LegalInformation;

namespace Rusell.Vehicles.Shared.Infrastructure.Persistence.EntityConfigurations;

public class VehicleLegalInformationConfiguration : IEntityTypeConfiguration<VehicleLegalInformation>
{
    public void Configure(EntityTypeBuilder<VehicleLegalInformation> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasConversion(v => v.Value, v => LegalInformationId.From(v));

        builder.OwnsOne(x => x.Type)
            .Property(x => x.Value)
            .HasMaxLength(64)
            .HasColumnName(nameof(VehicleLegalInformation.Type).ToDatabaseFormat());

        builder.OwnsOne(x => x.DueDate)
            .Property(x => x.Value)
            .HasColumnName(nameof(VehicleLegalInformation.DueDate).ToDatabaseFormat());

        builder.OwnsOne(x => x.RenovationDate)
            .Property(x => x.Value)
            .HasColumnName(nameof(VehicleLegalInformation.RenovationDate).ToDatabaseFormat());
    }
}
