using Mapster;
using Rusell.Shared.Domain.Bus.Query;

namespace Rusell.Addresses.Application.SearchAllByUser;

public class
    SearchAllAddressesByUserQueryHandler : IQueryHandler<SearchAllAddressesByUserQuery, IEnumerable<AddressResponse>>
{
    private readonly AddressesByUserSearcher _searcher;

    public SearchAllAddressesByUserQueryHandler(AddressesByUserSearcher searcher)
    {
        _searcher = searcher;
    }

    public async Task<IEnumerable<AddressResponse>> Handle(SearchAllAddressesByUserQuery request,
        CancellationToken cancellationToken)
    {
        var addresses = await _searcher.SearchAllByUser(request.UserId);
        return addresses.Adapt<IEnumerable<AddressResponse>>();
    }
}
