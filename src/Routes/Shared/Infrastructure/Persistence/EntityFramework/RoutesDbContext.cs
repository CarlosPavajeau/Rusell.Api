using Microsoft.EntityFrameworkCore;
using Rusell.Routes.Companies.Domain;
using Rusell.Routes.Domain;

namespace Rusell.Routes.Shared.Infrastructure.Persistence.EntityFramework;

public class RoutesDbContext : DbContext
{
    public RoutesDbContext(DbContextOptions<RoutesDbContext> options) : base(options)
    {
    }

    public DbSet<Company> Companies { get; set; }
    public DbSet<Route> Routes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(RoutesDbContext).Assembly);
    }
}
