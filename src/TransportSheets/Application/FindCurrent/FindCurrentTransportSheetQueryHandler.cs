using Mapster;
using Rusell.Shared.Domain.Bus.Query;
using Rusell.TransportSheets.Domain;

namespace Rusell.TransportSheets.Application.FindCurrent;

public class
    FindCurrentTransportSheetQueryHandler : IQueryHandler<FindCurrentTransportSheetQuery, TransportSheetResponse?>
{
    private readonly CurrentTransportSheetFinder _finder;

    public FindCurrentTransportSheetQueryHandler(CurrentTransportSheetFinder finder)
    {
        _finder = finder;
    }

    public async Task<TransportSheetResponse?> Handle(FindCurrentTransportSheetQuery request,
        CancellationToken cancellationToken)
    {
        var found = await _finder.FindCurrent(CompanyId.From(request.CompanyId));

        return found?.Adapt<TransportSheetResponse>();
    }
}
