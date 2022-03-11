using Rusell.Shared.Domain.Repository;

namespace Rusell.TransportSheets.Domain;

public interface ITransportSheetsRepository : IRepository<TransportSheet, TransportSheetId>
{
    Task<TransportSheet?> FindCurrent(CompanyId companyId);
}
