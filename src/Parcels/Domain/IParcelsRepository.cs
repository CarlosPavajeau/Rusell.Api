using Rusell.Shared.Domain.Repository;

namespace Rusell.Parcels.Domain;

public interface IParcelsRepository : IRepository<Parcel, ParcelId>
{
}
