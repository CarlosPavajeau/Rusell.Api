using Mapster;
using Rusell.BankDrafts.Application;
using Rusell.BankDrafts.Domain;

namespace Rusell.BankDrafts.Shared.Infrastructure.Mapping;

public class BankDraftToBankDraftResponse : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<BankDraft, BankDraftResponse>()
            .MapWith(s => new BankDraftResponse(
                s.Date,
                s.Amount,
                s.Cost,
                s.Total,
                s.State,
                s.Dispatcher.FullName,
                s.Sender.FullName,
                s.Receiver.FullName,
                s.Company.Name));
    }
}
