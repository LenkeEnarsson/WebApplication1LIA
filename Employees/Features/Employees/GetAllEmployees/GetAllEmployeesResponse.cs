namespace WebApplication3.Features.Employees.GetAllEmployees;

public sealed record GetAllEmployeesResponse(IReadOnlyList<GetAllEmployeesResponseItem> Employees);

public record GetAllEmployeesResponseItem(Guid Id, string GivenName, string SurName);