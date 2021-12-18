using Rusell.Routes.Application.SearchAllByFromTo;

namespace Rusell.Routes.Api.Controllers.Requests;

public class GetRoutesFromToQueryParams
{
    public Address From { get; set; }
    public Address To { get; set; }
}
