using Rusell.Shared.Domain.Repository;

namespace Rusell.BankDrafts.Domain;

public interface IBankDraftsRepository : IRepository<BankDraft, BankDraftId>
{
}
