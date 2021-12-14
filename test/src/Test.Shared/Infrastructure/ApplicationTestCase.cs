using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;

namespace Rusell.Test.Shared.Infrastructure;

public abstract class ApplicationTestCase<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
{
  protected override void ConfigureWebHost(IWebHostBuilder builder)
  {
    builder.ConfigureServices(Services());
  }

  protected new abstract Action<IServiceCollection> Services();
}