using Rusell.BankDrafts.Clients.Domain;
using Rusell.BankDrafts.Domain;

namespace Rusell.BankDrafts.Application.SearchAllBySender;

public class BankDraftsBySenderSearcher
{
    private readonly IBankDraftsRepository _repository;

    public BankDraftsBySenderSearcher(IBankDraftsRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<BankDraft>> SearchAllBySender(ClientId senderId)
    {
        return await _repository.SearchAll(x => x.SenderId == senderId);
    }
}
