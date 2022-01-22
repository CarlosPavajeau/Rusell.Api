using Mapster;
using Rusell.BankDrafts.Application.Create;
using Rusell.BankDrafts.Domain;

namespace Rusell.BankDrafts.Shared.Infrastructure.Mapping;

public class CreateBankDraftCommandToBankDraft : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateBankDraftCommand, BankDraft>()
            .MapWith(v => new BankDraftBuilder()
                .WithId(Guid.NewGuid())
                .WithDate(DateTime.UtcNow)
                .WithAmount(v.Amount)
                .WithCost(v.Cost)
                .WithTotal(v.Amount + v.Cost)
                .WithState(BankDraftState.Created)
                .WithDispatcherId(v.DispatcherId)
                .WithSenderId(v.SenderId)
                .WithReceiverId(v.ReceiverId)
                .WithCompanyId(v.CompanyId)
                .Build());
    }
}
