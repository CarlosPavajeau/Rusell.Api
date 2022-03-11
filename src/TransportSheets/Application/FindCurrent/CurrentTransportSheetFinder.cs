using Rusell.TransportSheets.Domain;

namespace Rusell.TransportSheets.Application.FindCurrent;

public class CurrentTransportSheetFinder
{
    private readonly ITransportSheetsRepository _repository;

    public CurrentTransportSheetFinder(ITransportSheetsRepository repository)
    {
        _repository = repository;
    }

    public async Task<TransportSheet?> FindCurrent(CompanyId companyId) => await _repository.FindCurrent(companyId);
}
