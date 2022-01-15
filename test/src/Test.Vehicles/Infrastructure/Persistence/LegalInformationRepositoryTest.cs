using System;
using System.Threading.Tasks;
using FluentAssertions;
using Rusell.Test.Shared.Domain;
using Rusell.Vehicles.Domain.LegalInformation;
using Xunit;

namespace Rusell.Test.Vehicles.Infrastructure.Persistence;

public class LegalInformationRepositoryTest : VehiclesContextInfrastructureTestCase
{
    private ILegalInformationRepository Repository => GetService<ILegalInformationRepository>();

    [Fact]
    public async Task Save_Should_Save_A_Legal_Information()
    {
        var legalInformation =
            VehicleLegalInformation.Create(WordMother.Random(), DateTime.Now, DateTime.Now, WordMother.Random());

        await Repository.Save(legalInformation);
    }

    [Fact]
    public async Task SearchAll_Should_Return_All_Vehicle_Legal_Information()
    {
        var legalInformation =
            VehicleLegalInformation.Create(WordMother.Random(), DateTime.Now, DateTime.Now, WordMother.Random());

        await Repository.Save(legalInformation);

        var result = await Repository.SearchAll(x => x.VehicleLicensePlate == legalInformation.VehicleLicensePlate);

        result.Should().NotBeEmpty();
    }

    [Fact]
    public async Task Find_Should_Return_Vehicle_Legal_Information()
    {
        var legalInformation =
            VehicleLegalInformation.Create(WordMother.Random(), DateTime.Now, DateTime.Now, WordMother.Random());

        await Repository.Save(legalInformation);

        var result = await Repository.Find(legalInformation.Id);

        result.Should().NotBeNull();
    }
}
