using Rusell.Parcels.Domain;

namespace Rusell.Parcels.Companies.Domain;

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

    public ICollection<Parcel> Parcels { get; set; }
}
