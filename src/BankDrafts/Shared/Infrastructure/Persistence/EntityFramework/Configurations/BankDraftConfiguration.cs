using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rusell.BankDrafts.Domain;
using Rusell.Shared.Extensions;

namespace Rusell.BankDrafts.Shared.Infrastructure.Persistence.EntityFramework.Configurations;

public class BankDraftConfiguration : IEntityTypeConfiguration<BankDraft>
{
    public void Configure(EntityTypeBuilder<BankDraft> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasConversion(v => v.Value, v => BankDraftId.From(v));

        builder.OwnsOne(x => x.Date)
            .Property(x => x.Value)
            .HasColumnName(nameof(BankDraft.Date).ToDatabaseFormat());

        builder.OwnsOne(x => x.Amount)
            .Property(x => x.Value)
            .HasColumnName(nameof(BankDraft.Amount).ToDatabaseFormat());

        builder.OwnsOne(x => x.Cost)
            .Property(x => x.Value)
            .HasColumnName(nameof(BankDraft.Company).ToDatabaseFormat());

        builder.OwnsOne(x => x.Total)
            .Property(x => x.Value)
            .HasColumnName(nameof(BankDraft.Total).ToDatabaseFormat());

        builder.Property(x => x.State)
            .HasConversion(
                v => v.ToString(),
                v => (BankDraftState) Enum.Parse(typeof(BankDraftState), v))
            .HasMaxLength(64);

        builder.HasOne(x => x.Dispatcher)
            .WithMany(x => x.BankDrafts)
            .HasForeignKey(x => x.DispatcherId)
            .IsRequired();

        builder.HasOne(x => x.Sender)
            .WithMany(x => x.BankDraftsSent)
            .HasForeignKey(x => x.SenderId)
            .IsRequired();

        builder.HasOne(x => x.Receiver)
            .WithMany(x => x.BankDraftsReceived)
            .HasForeignKey(x => x.ReceiverId)
            .IsRequired();

        builder.HasOne(x => x.Company)
            .WithMany(x => x.BankDrafts)
            .HasForeignKey(x => x.CompanyId)
            .IsRequired();
    }
}
