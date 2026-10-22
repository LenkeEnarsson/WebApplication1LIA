using Workloads.Features.Models;

namespace Workloads.Features.Workloads.GetWorkloadsByEmployee;

public sealed record GetWorkloadsByEmployeeResponse(IReadOnlyList<GetWorkloadsByCustomerResponseItem> Workloads);

public sealed record GetWorkloadsByCustomerResponseItem(
  Guid Id,
  Guid EmployeeId,
  Guid CustomerId,
  DateTimeOffset Start,
  DateTimeOffset? Stop,
  string Notes,
  WorkloadCustomer? Customer,
  WorkloadEmployee? Employee
);