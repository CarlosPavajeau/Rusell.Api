using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Rusell.Test.Shared.Infrastructure;

public abstract class InfrastructureTestCase<TStartup> where TStartup : class
{
    private readonly IHost _host;

    protected InfrastructureTestCase()
    {
        Setup();
    }

    protected abstract void Setup();

    protected void Finish()
    {
        _host.Dispose();
    }

    protected abstract Action<IServiceCollection> Services();

    private static IConfigurationRoot Configuration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(AppContext.BaseDirectory))
            .AddJsonFile("appsettings.json", true, true);

        return builder.Build();
    }

    private IHost CreateHost()
    {
        var hostBuilder = new HostBuilder()
            .ConfigureWebHostDefaults(webHost =>
            {
                webHost.UseTestServer();
                webHost.UseStartup<TStartup>();
                webHost.ConfigureTestServices(Services());
                webHost.UseConfiguration(Configuration());
            });

        return hostBuilder.Start();
    }

    protected T? GetService<T>()
    {
        return _host.Services.GetService<T>();
    }
}
