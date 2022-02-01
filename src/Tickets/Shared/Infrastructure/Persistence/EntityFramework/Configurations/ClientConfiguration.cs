using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rusell.Shared.Extensions;
using Rusell.Tickets.Clients.Domain;

namespace Rusell.Tickets.Shared.Infrastructure.Persistence.EntityFramework.Configurations;

public class ClientConfiguration : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasConversion(v => v.Value, v => ClientId.From(v));

        builder.OwnsOne(x => x.FullName)
            .Property(x => x.Value)
            .HasMaxLength(256)
            .HasColumnName(nameof(Client.FullName).ToDatabaseFormat());
    }
}
