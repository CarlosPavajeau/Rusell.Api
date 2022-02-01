using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rusell.Shared.Extensions;
using Rusell.Tickets.Domain;

namespace Rusell.Tickets.Shared.Infrastructure.Persistence.EntityFramework.Configurations;

public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
{
    public void Configure(EntityTypeBuilder<Ticket> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasConversion(v => v.Value, v => TicketId.From(v));

        builder.OwnsOne(x => x.Date)
            .Property(x => x.Value)
            .HasColumnName(nameof(Ticket.Date).ToDatabaseFormat());

        builder.Property(x => x.State)
            .HasConversion(
                v => v.ToString(),
                v => (TicketState) Enum.Parse(typeof(TicketState), v))
            .HasMaxLength(64);

        builder.OwnsOne(x => x.SeatPrice)
            .Property(x => x.Value)
            .HasColumnName(nameof(Ticket.SeatPrice).ToDatabaseFormat());

        builder.OwnsOne(x => x.Seats)
            .Property(x => x.Value)
            .HasColumnName(nameof(Ticket.Seats).ToDatabaseFormat());

        builder.OwnsOne(x => x.Total)
            .Property(x => x.Value)
            .HasColumnName(nameof(Ticket.Total).ToDatabaseFormat());

        builder.HasOne(x => x.Client)
            .WithMany(x => x.Tickets)
            .HasForeignKey(x => x.ClientId)
            .IsRequired();

        builder.OwnsOne(x => x.TransportSheetId)
            .Property(x => x.Value)
            .HasColumnName(nameof(Ticket.TransportSheetId).ToDatabaseFormat());
        builder.OwnsOne(x => x.TransportSheetId)
            .HasIndex(x => x.Value);
    }
}
