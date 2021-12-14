using Rusell.Shared.Domain;
using Rusell.Shared.Domain.Aggregate;
using Rusell.Shared.Domain.ValueObject;

namespace Rusell.Companies.Domain;

public class Company : AggregateRoot
{
    public Company()
    {
        Id = CompanyId.From(Guid.NewGuid());
    }

    public CompanyId Id { get; set; }
    public CompanyName Name { get; set; }
    public Nit? Nit { get; set; }
    public CompanyInfo Info { get; set; }

    public UserId UserId { get; set; }
}
