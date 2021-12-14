using ValueOf;

namespace Rusell.Companies.Domain;

public class CompanyName : ValueOf<string, CompanyName>
{
  public static implicit operator string(CompanyName companyName) => companyName.Value;
  public static implicit operator CompanyName(string companyName) => From(companyName);
}