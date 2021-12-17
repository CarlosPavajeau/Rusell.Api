using Rusell.Companies.Api.Extensions;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();
builder.Host.UseSerilog();

builder.Services
    .AddInfrastructure(builder.Configuration)
    .AddApplication();
builder.Services.AddRouting(options => { options.LowercaseUrls = true; });
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

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
namespace Rusell.Companies.Api
{
    public class Program
    {
    }
}
#pragma warning restore CA1050 // Declare types in namespaces
