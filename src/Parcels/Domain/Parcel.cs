using Rusell.Parcels.Clients.Domain;
using Rusell.Parcels.Companies.Domain;
using Rusell.Parcels.Employees.Domain;
using Rusell.Shared.Domain.Aggregate;

namespace Rusell.Parcels.Domain;

public class Parcel : AggregateRoot
{
    internal Parcel()
    {
        // required for EF
    }

    public ParcelId Id { get; set; }
    public ParcelDate Date { get; set; }
    public ParcelDescription Description { get; set; }
    public ParcelCost Cost { get; set; }
    public ParcelState State { get; set; }

    public VehicleLicensePlate VehicleLicensePlate { get; set; }

    public EmployeeId DispatcherId { get; set; }
    public Employee Dispatcher { get; set; }

    public ClientId SenderId { get; set; }
    public Client Sender { get; set; }

    public ClientId ReceiverId { get; set; }
    public Client Receiver { get; set; }

    public CompanyId CompanyId { get; set; }
    public Company Company { get; set; }
}
