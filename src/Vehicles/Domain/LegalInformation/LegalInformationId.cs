using ValueOf;

namespace Rusell.Vehicles.Domain.LegalInformation;

public class LegalInformationId : ValueOf<Guid, LegalInformationId>
{
    public static implicit operator Guid(LegalInformationId legalInformationId) => legalInformationId.Value;
    public static implicit operator LegalInformationId(Guid legalInformationId) => From(legalInformationId);
}
