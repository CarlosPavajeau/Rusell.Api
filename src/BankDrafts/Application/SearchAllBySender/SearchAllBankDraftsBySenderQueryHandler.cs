using Mapster;
using Rusell.BankDrafts.Clients.Domain;
using Rusell.Shared.Domain.Bus.Query;

namespace Rusell.BankDrafts.Application.SearchAllBySender;

public class
    SearchAllBankDraftsBySenderQueryHandler : IQueryHandler<SearchAllBankDraftsBySenderQuery,
        IEnumerable<BankDraftResponse>>
{
    private readonly BankDraftsBySenderSearcher _searcher;

    public SearchAllBankDraftsBySenderQueryHandler(BankDraftsBySenderSearcher searcher)
    {
        _searcher = searcher;
    }

    public async Task<IEnumerable<BankDraftResponse>> Handle(SearchAllBankDraftsBySenderQuery request,
        CancellationToken cancellationToken)
    {
        var bankDrafts = await _searcher.SearchAllBySender(ClientId.From(request.SenderId));
        return bankDrafts.Adapt<IEnumerable<BankDraftResponse>>();
    }
}
