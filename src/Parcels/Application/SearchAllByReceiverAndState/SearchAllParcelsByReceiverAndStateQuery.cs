using Rusell.Parcels.Domain;
using Rusell.Shared.Domain.Bus.Query;

namespace Rusell.Parcels.Application.SearchAllByReceiverAndState;

public record SearchAllParcelsByReceiverAndStateQuery
    (string ReceiverId, ParcelState State) : Query<IEnumerable<ParcelResponse>>;
