using Rusell.BankDrafts.Domain;

namespace Rusell.BankDrafts.Companies.Domain;

public class Company
{
    public Company(CompanyId id, CompanyName name)
    {
        Id = id;
        Name = name;
    }

    private Company()
    {
        // required by EF
    }

    public CompanyId Id { get; set; }
    public CompanyName Name { get; set; }

    public IList<BankDraft> BankDrafts { get; set; }
}
