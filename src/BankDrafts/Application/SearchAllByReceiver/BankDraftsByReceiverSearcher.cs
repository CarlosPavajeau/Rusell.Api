using Rusell.BankDrafts.Clients.Domain;
using Rusell.BankDrafts.Domain;

namespace Rusell.BankDrafts.Application.SearchAllByReceiver;

public class BankDraftsByReceiverSearcher
{
    private readonly IBankDraftsRepository _repository;

    public BankDraftsByReceiverSearcher(IBankDraftsRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<BankDraft>> SearchAllByReceiver(ClientId receiverId)
    {
        return await _repository.SearchAll(x => x.ReceiverId == receiverId);
    }
}
