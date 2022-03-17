using System;
using Rusell.Test.Shared.Domain;
using Rusell.TransportSheets.Domain;
using Rusell.TransportSheets.Employees.Domain;

namespace Rusell.Test.TransportSheets.Domain;

public static class TransportSheetMother
{
    public static TransportSheet Random(Guid companyId)
    {
        var dispatcher = new Employee(MotherCreator.Random().Guid().ToString(), WordMother.Random());

        var transportSheet = new TransportSheetBuilder()
            .WithId(Guid.NewGuid())
            .WithDate(DateTime.UtcNow)
            .WithQuota(MotherCreator.Random().UInt(1, 100))
            .WithVehicleLicensePlate(MotherCreator.Random().String(10))
            .WithDispatcherId(dispatcher.Id)
            .WithDispatcher(dispatcher)
            .WithRouteId(MotherCreator.Random().Guid())
            .WithCompanyId(CompanyId.From(companyId))
            .Build();

        return transportSheet;
    }
}
