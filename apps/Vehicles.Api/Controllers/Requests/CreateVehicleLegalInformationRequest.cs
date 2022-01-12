namespace Rusell.Vehicles.Api.Controllers.Requests;

public record CreateVehicleLegalInformationRequest(string Type, DateTime DueDate, DateTime RenovationDate);
