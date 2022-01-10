using ValueOf;

namespace Rusell.Vehicles.Domain.LegalInformation;

public class LegalInformationType : ValueOf<string, LegalInformationType>
{
    public static implicit operator string(LegalInformationType legalInformationType) => legalInformationType.Value;
    public static implicit operator LegalInformationType(string legalInformationType) => From(legalInformationType);
}
