using Microsoft.EntityFrameworkCore;
using Rusell.Parcels.Clients.Domain;
using Rusell.Parcels.Companies.Domain;
using Rusell.Parcels.Domain;
using Rusell.Parcels.Employees.Domain;

namespace Rusell.Parcels.Shared.Infrastructure.Persistence.EntityFramework;

public class ParcelsDbContext : DbContext
{
    public ParcelsDbContext(DbContextOptions<ParcelsDbContext> options) : base(options)
    {
    }

    public DbSet<Parcel> Parcels { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<Employee> Employees { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ParcelsDbContext).Assembly);
    }
}
