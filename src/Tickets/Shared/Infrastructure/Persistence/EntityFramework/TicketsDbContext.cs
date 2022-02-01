using Microsoft.EntityFrameworkCore;
using Rusell.Tickets.Clients.Domain;
using Rusell.Tickets.Domain;

namespace Rusell.Tickets.Shared.Infrastructure.Persistence.EntityFramework;

public class TicketsDbContext : DbContext
{
    public TicketsDbContext(DbContextOptions<TicketsDbContext> options) : base(options)
    {
    }

    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<Client> Clients { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TicketsDbContext).Assembly);
    }
}
