using Mapster;
using Rusell.Shared.Domain.Bus.Query;

namespace Rusell.Addresses.Application.SearchAll;

public class SearchAllAddressesQueryHandler : IQueryHandler<SearchAllAddressesQuery, IEnumerable<AddressResponse>>
{
    private readonly AddressesSearcher _searcher;

    public SearchAllAddressesQueryHandler(AddressesSearcher searcher)
    {
        _searcher = searcher;
    }

    public async Task<IEnumerable<AddressResponse>> Handle(SearchAllAddressesQuery request,
        CancellationToken cancellationToken)
    {
        var addresses = await _searcher.SearchAll();

        return addresses.Adapt<IEnumerable<AddressResponse>>();
    }
}
