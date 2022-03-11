using Rusell.Shared.Domain.Bus.Query;

namespace Rusell.TransportSheets.Application.FindCurrent;

public record FindCurrentTransportSheetQuery(Guid CompanyId) : Query<TransportSheetResponse?>;
