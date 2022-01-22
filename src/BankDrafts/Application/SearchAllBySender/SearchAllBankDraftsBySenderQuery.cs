using Rusell.Shared.Domain.Bus.Query;

namespace Rusell.BankDrafts.Application.SearchAllBySender;

public record SearchAllBankDraftsBySenderQuery(string SenderId) : Query<IEnumerable<BankDraftResponse>>;
