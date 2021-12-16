using Rusell.Routes.Domain;

namespace Rusell.Routes.Companies.Domain;

public class Company
{
    public CompanyId Id { get; set; }
    public CompanyName Name { get; set; }

    public ICollection<Route> Routes { get; set; } = new HashSet<Route>();
}
