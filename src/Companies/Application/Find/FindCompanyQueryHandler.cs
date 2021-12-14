using Mapster;
using Rusell.Shared.Domain.Bus.Query;

namespace Rusell.Companies.Application.Find;

public class FindCompanyQueryHandler : IQueryHandler<FindCompanyQuery, CompanyResponse>
{
    private readonly CompanyFinder _finder;

    public FindCompanyQueryHandler(CompanyFinder finder)
    {
        _finder = finder;
    }

    public async Task<CompanyResponse> Handle(FindCompanyQuery request, CancellationToken cancellationToken)
    {
        var company = await _finder.Find(request.Id);
        return company.Adapt<CompanyResponse>();
    }
}