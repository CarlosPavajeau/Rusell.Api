using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Rusell.Shared.Extensions.DependencyInjection;

public static class MigrateDatabaseExtension
{
    public static IHost MigrateDatabase<TDbContext>(this IHost host) where TDbContext : DbContext
    {
        using var scope = host.Services.CreateScope();
        var services = scope.ServiceProvider;

        try
        {
            var context = services.GetRequiredService<TDbContext>();
            if (context.Database.GetPendingMigrations().Any()) context.Database.Migrate();
        }
        catch (Exception e)
        {
            var logger = services.GetRequiredService<ILogger<TDbContext>>();
            logger.LogError(e, "An error occurred while migrating the database");
        }

        return host;
    }
}
