using Mapster;
using Rusell.Shared.Domain.Bus.Query;

namespace Rusell.BankDrafts.Application.SearchAllByReceiver;

public class
    SearchAllBankDraftsByReceiverQueryHandler : IQueryHandler<SearchAllBankDraftsByReceiverQuery,
        IEnumerable<BankDraftResponse>>
{
    private readonly BankDraftsByReceiverSearcher _searcher;

    public SearchAllBankDraftsByReceiverQueryHandler(BankDraftsByReceiverSearcher searcher)
    {
        _searcher = searcher;
    }

    public async Task<IEnumerable<BankDraftResponse>> Handle(SearchAllBankDraftsByReceiverQuery request,
        CancellationToken cancellationToken)
    {
        var bankDrafts = await _searcher.SearchAllByReceiver(request.ReceiverId);
        return bankDrafts.Adapt<IEnumerable<BankDraftResponse>>();
    }
}
