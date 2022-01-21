using Microsoft.EntityFrameworkCore;
using Rusell.BankDrafts.Clients.Domain;
using Rusell.BankDrafts.Companies.Domain;
using Rusell.BankDrafts.Domain;
using Rusell.BankDrafts.Employees.Domain;

namespace Rusell.BankDrafts.Shared.Infrastructure.Persistence.EntityFramework;

public class BankDraftsDbContext : DbContext
{
    public BankDraftsDbContext(DbContextOptions<BankDraftsDbContext> options) : base(options)
    {
    }

    public DbSet<BankDraft> BankDrafts { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<Employee> Employees { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BankDraftsDbContext).Assembly);
    }
}
