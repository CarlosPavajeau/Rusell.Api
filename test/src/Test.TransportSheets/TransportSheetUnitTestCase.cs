using Moq;
using Rusell.Test.Shared.Infrastructure;
using Rusell.TransportSheets.Domain;

namespace Rusell.Test.TransportSheets;

public class TransportSheetUnitTestCase : UnitTestCase
{
    protected readonly Mock<ITransportSheetsRepository> Repository;

    protected TransportSheetUnitTestCase()
    {
        Repository = new Mock<ITransportSheetsRepository>();
    }
}
