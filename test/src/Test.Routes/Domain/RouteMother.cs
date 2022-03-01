using System;
using Rusell.Routes.Addresses.Domain;
using Rusell.Routes.Domain;
using Rusell.Test.Shared.Domain;

namespace Rusell.Test.Routes.Domain;

public static class RouteMother
{
    public static Route Random(Guid companyId)
    {
        var from = new Address
        {
            Id = Guid.NewGuid(),
            Country = WordMother.Random(),
            City = WordMother.Random(),
            State = WordMother.Random()
        };

        var to = new Address
        {
            Id = Guid.NewGuid(),
            Country = WordMother.Random(),
            City = WordMother.Random(),
            State = WordMother.Random()
        };

        return new Route
        {
            From = from,
            FromId = from.Id,
            To = to,
            ToId = to.Id,
            CompanyId = companyId,
            Cost = MotherCreator.Random().Decimal(100, 100000),
            IsCustomerDroppedOffAtHome = MotherCreator.Random().Bool(),
            IsCustomerPickedUpAtHome = MotherCreator.Random().Bool()
        };
    }
}
