using Microsoft.EntityFrameworkCore;
using Rusell.Clients.Domain;

namespace Rusell.Clients.Shared.Infrastructure.Persistence.EntityFramework;

public class ClientsDbContext : DbContext
{
    public ClientsDbContext(DbContextOptions<ClientsDbContext> options) : base(options)
    {
    }

    public DbSet<Client> Clients { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ClientsDbContext).Assembly);
    }
}
