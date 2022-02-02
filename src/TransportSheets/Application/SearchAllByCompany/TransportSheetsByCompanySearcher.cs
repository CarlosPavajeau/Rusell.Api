using Rusell.TransportSheets.Domain;

namespace Rusell.TransportSheets.Application.SearchAllByCompany;

public class TransportSheetsByCompanySearcher
{
    private readonly ITransportSheetsRepository _repository;

    public TransportSheetsByCompanySearcher(ITransportSheetsRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<TransportSheet>> SearchAllByCompany(CompanyId companyId)
    {
        return await _repository.SearchAll(x => x.CompanyId == companyId);
    }
}
