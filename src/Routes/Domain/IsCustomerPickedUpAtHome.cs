using ValueOf;

namespace Rusell.Routes.Domain;

public class IsCustomerPickedUpAtHome : ValueOf<bool, IsCustomerPickedUpAtHome>
{
    public static implicit operator bool(IsCustomerPickedUpAtHome isCustomerPickedUpAtHome) =>
        isCustomerPickedUpAtHome.Value;

    public static implicit operator IsCustomerPickedUpAtHome(bool isCustomerPickedUpAtHome) =>
        From(isCustomerPickedUpAtHome);
}
