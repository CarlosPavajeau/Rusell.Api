using ValueOf;

namespace Rusell.Companies.Domain;

public class CompanyInfo : ValueOf<string, CompanyInfo>
{
  public static implicit operator string(CompanyInfo companyInfo) => companyInfo.Value;
  public static implicit operator CompanyInfo(string companyInfo) => From(companyInfo);
}