using ValueOf;

namespace Rusell.Routes.Domain;

public class IsCustomerDroppedOffAtHome : ValueOf<bool, IsCustomerDroppedOffAtHome>
{
    public static implicit operator bool(IsCustomerDroppedOffAtHome isCustomerDroppedOffAtHome) =>
        isCustomerDroppedOffAtHome.Value;

    public static implicit operator IsCustomerDroppedOffAtHome(bool isCustomerDroppedOffAtHome) =>
        From(isCustomerDroppedOffAtHome);
}
