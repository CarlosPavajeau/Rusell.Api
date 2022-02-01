using Rusell.Parcels.Domain;

namespace Rusell.Parcels.Application;

public record ParcelResponse(
    DateTime Date,
    string Description,
    decimal Cost,
    ParcelState State,
    string VehicleLicensePlate,
    string DispatcherName,
    string SenderName,
    string ReceiverName,
    string CompanyName);
