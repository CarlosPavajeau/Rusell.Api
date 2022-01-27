using Rusell.BankDrafts.Clients.Domain;
using Rusell.BankDrafts.Domain;

namespace Rusell.BankDrafts.Application.SearchAllByReceiverAndState;

public class BankDraftsByReceiverAndStateSearcher
{
    private readonly IBankDraftsRepository _repository;

    public BankDraftsByReceiverAndStateSearcher(IBankDraftsRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<BankDraft>> SearchAllByReceiverAndState(ClientId receiverId, BankDraftState state)
    {
        return await _repository.SearchAll(x => x.ReceiverId == receiverId && x.State == state);
    }
}
