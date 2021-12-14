using Microsoft.EntityFrameworkCore;
using Rusell.Companies.Domain;

namespace Rusell.Companies.Shared.Infrastructure.Persistence.EntityFramework;

public class CompaniesDbContext : DbContext
{
  public CompaniesDbContext(DbContextOptions<CompaniesDbContext> options) : base(options)
  {
  }

  public DbSet<Company> Companies { get; set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);

    modelBuilder.ApplyConfigurationsFromAssembly(typeof(CompaniesDbContext).Assembly);
  }
}