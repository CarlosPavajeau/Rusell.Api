using Mapster;
using Rusell.Shared.Domain.Bus.Query;

namespace Rusell.Companies.Application.FindByNit;

public class FindCompanyByNitQueryHandler : IQueryHandler<FindCompanyByNitQuery, CompanyResponse?>
{
    private readonly CompanyByNitFinder _finder;

    public FindCompanyByNitQueryHandler(CompanyByNitFinder finder)
    {
        _finder = finder;
    }

    public async Task<CompanyResponse?> Handle(FindCompanyByNitQuery request, CancellationToken cancellationToken)
    {
        var company = await _finder.FindByNit(request.Nit);
        return company?.Adapt<CompanyResponse>();
    }
}
