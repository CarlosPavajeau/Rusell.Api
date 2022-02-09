using System;
using Rusell.Test.Shared.Domain;
using Rusell.Vehicles.Domain;
using Rusell.Vehicles.Employees.Domain;

namespace Rusell.Test.Vehicles.Domain;

public static class VehicleMother
{
    public static Vehicle Random() => Random(Guid.NewGuid());

    public static Vehicle Random(Guid companyId)
    {
        var ownerId = Guid.NewGuid().ToString();
        var driverId = Guid.NewGuid().ToString();

        return new VehicleBuilder()
            .WithLicensePlate(Guid.NewGuid().ToString())
            .WithInternalNumber(Guid.NewGuid().ToString())
            .WithPropertyCard(Guid.NewGuid().ToString())
            .WithType(WordMother.Random())
            .WithMark(WordMother.Random())
            .WithModel(WordMother.Random())
            .WithModelNumber(WordMother.Random())
            .WithColor(WordMother.Random())
            .WithChairs(10)
            .WithEngineNumber(Guid.NewGuid().ToString())
            .WithChassisNumber(Guid.NewGuid().ToString())
            .WithOwnerId(ownerId)
            .WithOwner(new Employee(ownerId, WordMother.Random()))
            .WithDriverId(driverId)
            .WithDriver(new Employee(driverId, WordMother.Random()))
            .WithCompanyId(companyId)
            .Build();
    }
}
