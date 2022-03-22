using ValueOf;

namespace Rusell.Companies.Domain;

public class CompanyId : ValueOf<Guid, CompanyId>
{
    public static implicit operator Guid(CompanyId companyId) => companyId.Value;
    public static implicit operator CompanyId(Guid companyId) => From(companyId);
}
