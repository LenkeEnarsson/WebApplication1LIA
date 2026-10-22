namespace Workloads.Features.WorkloadCustomers.GetAllWorkloadCustomers;

public sealed record GetAllWorkloadCustomersResponse(IReadOnlyList<GetAllWorkloadCustomersResponseItem> Customers);

public sealed record GetAllWorkloadCustomersResponseItem(
  Guid Id,
  string CompanyName
);