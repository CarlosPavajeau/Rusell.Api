using Rusell.Shared.Domain.Bus.Query;

namespace Rusell.TransportSheets.Application.SearchAllByCompany;

public record SearchAllTransportSheetsByCompanyQuery(Guid CompanyId) : Query<IEnumerable<TransportSheetResponse>>;
