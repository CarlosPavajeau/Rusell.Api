using Rusell.Shared.Domain.Aggregate;
using Rusell.TransportSheets.Employees.Domain;

namespace Rusell.TransportSheets.Domain;

public class TransportSheet : AggregateRoot
{
    public TransportSheet(TransportSheetId id, TransportSheetDate date, TransportSheetDate departureTime,
        TransportSheetQuota quota, VehicleLicensePlate vehicleLicensePlate, EmployeeId dispatcherId,
        CompanyId companyId)
    {
        Id = id;
        Date = date;
        DepartureTime = departureTime;
        Quota = quota;
        VehicleLicensePlate = vehicleLicensePlate;
        DispatcherId = dispatcherId;
        CompanyId = companyId;
    }

    internal TransportSheet()
    {
        // required by EF
    }

    public TransportSheetId Id { get; set; }
    public TransportSheetDate Date { get; set; }
    public TransportSheetDate? DepartureTime { get; set; }
    public TransportSheetQuota Quota { get; set; }

    public VehicleLicensePlate VehicleLicensePlate { get; set; }

    public EmployeeId DispatcherId { get; set; }
    public Employee Dispatcher { get; set; }

    public CompanyId CompanyId { get; set; }
}
