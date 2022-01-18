using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rusell.Clients.Domain;
using Rusell.Shared.Extensions;

namespace Rusell.Clients.Shared.Infrastructure.Persistence.EntityConfigurations;

public class ClientConfiguration : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasConversion(v => v.Value, v => ClientId.From(v));

        builder.OwnsOne(x => x.FirstName)
            .Property(x => x.Value)
            .HasMaxLength(64)
            .HasColumnName(nameof(Client.FirstName).ToDatabaseFormat());

        builder.OwnsOne(x => x.MiddleName)
            .Property(x => x.Value)
            .HasMaxLength(64)
            .HasColumnName(nameof(Client.MiddleName).ToDatabaseFormat());

        builder.OwnsOne(x => x.FirstSurname)
            .Property(x => x.Value)
            .HasMaxLength(64)
            .HasColumnName(nameof(Client.FirstSurname).ToDatabaseFormat());

        builder.OwnsOne(x => x.SecondSurname)
            .Property(x => x.Value)
            .HasMaxLength(64)
            .HasColumnName(nameof(Client.SecondSurname).ToDatabaseFormat());

        builder.OwnsOne(x => x.PhoneNumber)
            .Property(x => x.Value)
            .HasMaxLength(10)
            .HasColumnName(nameof(Client.PhoneNumber).ToDatabaseFormat());

        builder.OwnsOne(x => x.UserId)
            .Property(x => x.Value)
            .HasMaxLength(256)
            .HasColumnName(nameof(Client.UserId).ToDatabaseFormat());

        builder.OwnsOne(x => x.UserId)
            .HasIndex(x => x.Value)
            .IsUnique();
    }
}
