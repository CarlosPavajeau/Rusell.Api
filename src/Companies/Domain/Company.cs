using Rusell.Shared.Domain.Aggregate;
using Rusell.Shared.Domain.Companies.Domain;
using Rusell.Shared.Domain.ValueObject;

namespace Rusell.Companies.Domain;

public class Company : AggregateRoot
{
    public Company(CompanyName name, Nit? nit, CompanyInfo info, UserId userId)
    {
        Id = CompanyId.From(Guid.NewGuid());
        Name = name;
        Nit = nit;
        Info = info;
        UserId = userId;
    }

    private Company()
    {
        // For EF
    }

    public CompanyId Id { get; set; }
    public CompanyName Name { get; set; }
    public Nit? Nit { get; set; }
    public CompanyInfo Info { get; set; }

    public UserId UserId { get; set; }

    public static Company Create(CompanyName name, Nit? nit, CompanyInfo info, UserId userId)
    {
        var company = new Company(name, nit, info, userId);
        company.Record(new CompanyCreatedDomainEvent(company.Id.Value.ToString(), company.Name));

        return company;
    }
}
