namespace Companies.Api.Controllers.Requests;

public record CreateCompanyRequest(string Name, string? Nit, string Info);
