using Rusell.BankDrafts.Domain;
using Rusell.Shared.Domain.Bus.Query;

namespace Rusell.BankDrafts.Application.SearchAllByReceiverAndState;

public record SearchAllBankDraftsByReceiverAndStateQuery
    (string ReceiverId, BankDraftState State) : Query<IEnumerable<BankDraftResponse>>;
