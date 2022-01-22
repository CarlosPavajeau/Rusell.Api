using Rusell.Shared.Domain.Bus.Query;

namespace Rusell.BankDrafts.Application.SearchAllByReceiver;

public record SearchAllBankDraftsByReceiverQuery(string ReceiverId) : Query<IEnumerable<BankDraftResponse>>;
