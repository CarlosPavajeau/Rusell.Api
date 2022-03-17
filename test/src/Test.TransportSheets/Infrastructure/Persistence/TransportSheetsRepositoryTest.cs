using System;
using System.Threading.Tasks;
using FluentAssertions;
using Rusell.Test.TransportSheets.Domain;
using Rusell.TransportSheets.Domain;
using Xunit;

namespace Rusell.Test.TransportSheets.Infrastructure.Persistence;

public class TransportSheetsRepositoryTest : TransportSheetsContextInfrastructureTestCase
{
    private ITransportSheetsRepository Repository => GetService<ITransportSheetsRepository>();

    [Fact]
    public async Task Save_Should_Save_TransportSheet()
    {
        var transportSheet = TransportSheetMother.Random(Guid.NewGuid());

        await Repository.Save(transportSheet);
    }

    [Fact]
    public async Task SearchAll_Should_Return_All_TransportSheets()
    {
        var transportSheet = TransportSheetMother.Random(Guid.NewGuid());

        await Repository.Save(transportSheet);

        var transportSheets = await Repository.SearchAll();

        transportSheets.Should().NotBeEmpty();
    }

    [Fact]
    public async Task FindCurrent_Should_Return_Current_TransportSheet()
    {
        var companyId = Guid.NewGuid();
        var transportSheet = TransportSheetMother.Random(companyId);

        await Repository.Save(transportSheet);

        var currentTransportSheet = await Repository.FindCurrent(CompanyId.From(companyId));

        currentTransportSheet.Should().NotBeNull();
    }
}
