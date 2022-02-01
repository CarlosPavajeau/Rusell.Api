using Rusell.Parcels.Clients.Domain;
using Rusell.Parcels.Domain;

namespace Rusell.Parcels.Application.SearchAllByReceiverAndState;

public class ParcelsByReceiverAndStateSearcher
{
    private readonly IParcelsRepository _repository;

    public ParcelsByReceiverAndStateSearcher(IParcelsRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Parcel>> SearchAllByReceiverAndState(ClientId receiverId, ParcelState state)
    {
        return await _repository.SearchAll(x => x.ReceiverId == receiverId && x.State == state);
    }
}
