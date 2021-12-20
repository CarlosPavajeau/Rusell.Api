using Microsoft.EntityFrameworkCore;
using Rusell.Employees.Domain;

namespace Rusell.Employees.Shared.Infrastructure.Persistence.EntityFramework;

public class EmployeesDbContext : DbContext
{
    public EmployeesDbContext(DbContextOptions<EmployeesDbContext> options) : base(options)
    {
    }

    public DbSet<Employee> Employees { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EmployeesDbContext).Assembly);
    }
}
