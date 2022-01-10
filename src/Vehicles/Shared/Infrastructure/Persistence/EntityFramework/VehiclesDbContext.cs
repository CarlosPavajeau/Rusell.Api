using Microsoft.EntityFrameworkCore;
using Rusell.Vehicles.Domain;
using Rusell.Vehicles.Employees.Domain;

namespace Rusell.Vehicles.Shared.Infrastructure.Persistence.EntityFramework;

public class VehiclesDbContext : DbContext
{
    public VehiclesDbContext(DbContextOptions<VehiclesDbContext> options) : base(options)
    {
    }

    public DbSet<Vehicle> Vehicles { get; set; }
    public DbSet<Employee> Employees { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(VehiclesDbContext).Assembly);
    }
}
