namespace Workloads.Features.WorkloadEmployees.GetAllWorkloadEmployees;

public sealed record GetAllWorkloadEmployeesResponse(IReadOnlyList<GetAllWorkloadEmployeesResponseItem> Customers);

public sealed record GetAllWorkloadEmployeesResponseItem(
  Guid Id,
  string GivenName,
  string Surname
);