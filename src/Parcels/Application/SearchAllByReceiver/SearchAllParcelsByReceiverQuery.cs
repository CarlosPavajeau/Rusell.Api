using Rusell.Shared.Domain.Bus.Query;

namespace Rusell.Parcels.Application.SearchAllByReceiver;

public record SearchAllParcelsByReceiverQuery(string ReceiverId) : Query<IEnumerable<ParcelResponse>>;
