using Rusell.BankDrafts.Application.SearchAllByReceiver;
using Rusell.BankDrafts.Application.SearchAllBySender;

namespace Rusell.BankDrafts.Api.Extensions.DependencyInjection;

public static class Application
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<ClientCreator, ClientCreator>();
        services.AddScoped<CompanyCreator, CompanyCreator>();
        services.AddScoped<EmployeeCreator, EmployeeCreator>();

        services.AddScoped<BankDraftCreator, BankDraftCreator>();
        services.AddScoped<BankDraftsByReceiverSearcher, BankDraftsByReceiverSearcher>();
        services.AddScoped<BankDraftsBySenderSearcher, BankDraftsBySenderSearcher>();

        services.AddDomainEventSubscriberInformationService(AssemblyHelper.GetInstance(Assemblies.BankDrafts));

        return services;
    }
}
