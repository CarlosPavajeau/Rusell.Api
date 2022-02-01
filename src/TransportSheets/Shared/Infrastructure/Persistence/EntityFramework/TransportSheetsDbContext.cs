using Microsoft.EntityFrameworkCore;
using Rusell.TransportSheets.Domain;
using Rusell.TransportSheets.Employees.Domain;

namespace Rusell.TransportSheets.Shared.Infrastructure.Persistence.EntityFramework;

public class TransportSheetsDbContext : DbContext
{
    public TransportSheetsDbContext(DbContextOptions<TransportSheetsDbContext> options) : base(options)
    {
    }

    public DbSet<TransportSheet> TransportSheets { get; set; }
    public DbSet<Employee> Employees { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TransportSheetsDbContext).Assembly);
    }
}
