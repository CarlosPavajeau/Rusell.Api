using Mapster;
using Rusell.Shared.Domain.Bus.Query;

namespace Rusell.Companies.Application.FindByUser;

public class FindCompanyByUserQueryHandler : IQueryHandler<FindCompanyByUserQuery, CompanyResponse?>
{
    private readonly CompanyByUserFinder _finder;

    public FindCompanyByUserQueryHandler(CompanyByUserFinder finder)
    {
        _finder = finder;
    }

    public async Task<CompanyResponse?> Handle(FindCompanyByUserQuery request, CancellationToken cancellationToken)
    {
        var company = await _finder.FindByUser(request.UserId);
        return company?.Adapt<CompanyResponse>();
    }
}
