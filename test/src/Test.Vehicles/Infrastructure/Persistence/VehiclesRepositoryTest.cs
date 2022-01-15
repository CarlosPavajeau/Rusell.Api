using System;
using System.Threading.Tasks;
using FluentAssertions;
using Rusell.Test.Vehicles.Domain;
using Rusell.Vehicles.Domain;
using Xunit;

namespace Rusell.Test.Vehicles.Infrastructure.Persistence;

public class VehiclesRepositoryTest : VehiclesContextInfrastructureTestCase
{
    private IVehiclesRepository Repository => GetService<IVehiclesRepository>();

    [Fact]
    public async Task Save_Should_Save_A_Vehicle()
    {
        var vehicle = VehicleMother.Random();

        await Repository.Save(vehicle);
    }

    [Fact]
    public async Task SearchAllByCompany_Should_Return_All_Vehicles()
    {
        var companyId = CompanyId.From(Guid.NewGuid());
        var vehicles = new[]
        {
            VehicleMother.Random(companyId),
            VehicleMother.Random(companyId)
        };
        foreach (var vehicle in vehicles) await Repository.Save(vehicle);

        var result = await Repository.SearchAll(x => x.CompanyId == companyId);

        result.Should().HaveCount(vehicles.Length);
    }

    [Fact]
    public async Task Find_Should_Return_A_Vehicle()
    {
        var vehicle = VehicleMother.Random();
        await Repository.Save(vehicle);

        var result = await Repository.Find(vehicle.LicensePlate);

        result.Should().NotBeNull();
    }
}
