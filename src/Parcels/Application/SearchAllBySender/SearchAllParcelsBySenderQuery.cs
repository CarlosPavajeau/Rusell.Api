using Rusell.Shared.Domain.Bus.Query;

namespace Rusell.Parcels.Application.SearchAllBySender;

public record SearchAllParcelsBySenderQuery(string SenderId) : Query<IEnumerable<ParcelResponse>>;
