using System;
using System.Threading.Tasks;
using FluentAssertions;
using Rusell.Parcels.Domain;
using Rusell.Shared.Domain.Persistence;
using Rusell.Test.Parcels.Domain;
using Xunit;

namespace Rusell.Test.Parcels.Infrastructure.Persistence;

public class ParcelsRepository : ParcelsContextInfrastructureTestCase
{
    private IParcelsRepository Repository => GetService<IParcelsRepository>();
    private IUnitWork UnitWork => GetService<IUnitWork>();

    [Fact]
    public async Task Save_Should_Save_Parcel()
    {
        var parcel = ParcelMother.Random(Guid.NewGuid());

        await Repository.Save(parcel);
    }

    [Fact]
    public async Task SearchAll_Should_Return_All_Parcels()
    {
        var parcel = ParcelMother.Random(Guid.NewGuid());
        await Repository.Save(parcel);

        var parcels = await Repository.SearchAll();
        parcels.Should().NotBeEmpty();
    }

    [Fact]
    public async Task Find_Should_Return_Parcel()
    {
        var parcel = ParcelMother.Random(Guid.NewGuid());
        await Repository.Save(parcel);

        var foundParcel = await Repository.Find(parcel.Id);
        foundParcel.Should().NotBeNull();
    }

    [Fact]
    public async Task Find_Should_Return_Null()
    {
        var foundParcel = await Repository.Find(ParcelId.From(Guid.NewGuid()));
        foundParcel.Should().BeNull();
    }

    [Fact]
    public async Task Update_Should_Update_Parcel()
    {
        var parcel = ParcelMother.Random(Guid.NewGuid());
        await Repository.Save(parcel);

        var foundParcel = await Repository.Find(parcel.Id, false);
        foundParcel.Should().NotBeNull();

        foundParcel!.State = ParcelState.Delivered;
        await UnitWork.SaveChanges();

        var updatedParcel = await Repository.Find(parcel.Id);
        updatedParcel.Should().NotBeNull();
        updatedParcel!.State.Should().Be(ParcelState.Delivered);
    }
}
