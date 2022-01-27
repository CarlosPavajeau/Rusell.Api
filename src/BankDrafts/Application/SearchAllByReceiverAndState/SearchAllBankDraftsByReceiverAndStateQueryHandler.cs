using Mapster;
using Rusell.Shared.Domain.Bus.Query;

namespace Rusell.BankDrafts.Application.SearchAllByReceiverAndState;

public class
    SearchAllBankDraftsByReceiverAndStateQueryHandler : IQueryHandler<SearchAllBankDraftsByReceiverAndStateQuery,
        IEnumerable<BankDraftResponse>>
{
    private readonly BankDraftsByReceiverAndStateSearcher _searcher;

    public SearchAllBankDraftsByReceiverAndStateQueryHandler(BankDraftsByReceiverAndStateSearcher searcher)
    {
        _searcher = searcher;
    }

    public async Task<IEnumerable<BankDraftResponse>> Handle(SearchAllBankDraftsByReceiverAndStateQuery request,
        CancellationToken cancellationToken)
    {
        var (receiverId, bankDraftState) = request;
        var bankDrafts = await _searcher.SearchAllByReceiverAndState(receiverId, bankDraftState);

        return bankDrafts.Adapt<IEnumerable<BankDraftResponse>>();
    }
}
