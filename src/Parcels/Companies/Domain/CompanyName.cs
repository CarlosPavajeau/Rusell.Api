using ValueOf;

namespace Rusell.Parcels.Companies.Domain;

public class CompanyName : ValueOf<string, CompanyName>
{
    public static implicit operator string(CompanyName companyName) => companyName.Value;
    public static implicit operator CompanyName(string companyName) => From(companyName);
}
