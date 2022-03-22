using Rusell.Clients.Api.Extensions.DependencyInjection;
using Rusell.Clients.Shared.Infrastructure.Persistence.EntityFramework;
using Rusell.Shared.Extensions.DependencyInjection;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();
builder.Host.UseSerilog();

builder.Services.AddInfrastructure(builder.Configuration)
    .AddApplication();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsProduction())
{
    app.MigrateDatabase<ClientsDbContext>();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

#pragma warning disable CA1050 // Declare types in namespaces
namespace Rusell.Clients.Api
{
    public class Program
    {
        // For testing purposes
    }
}
#pragma warning restore CA1050 // Declare types in namespaces
