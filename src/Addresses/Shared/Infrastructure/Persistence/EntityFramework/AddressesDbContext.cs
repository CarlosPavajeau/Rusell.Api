using Microsoft.EntityFrameworkCore;
using Rusell.Addresses.Domain;

namespace Rusell.Addresses.Shared.Infrastructure.Persistence.EntityFramework;

public class AddressesDbContext : DbContext
{
    public AddressesDbContext(DbContextOptions<AddressesDbContext> options) : base(options)
    {
    }

    public DbSet<Address> Addresses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AddressesDbContext).Assembly);
    }
}