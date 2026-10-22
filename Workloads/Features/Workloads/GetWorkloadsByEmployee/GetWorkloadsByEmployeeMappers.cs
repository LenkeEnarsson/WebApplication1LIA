using FastEndpoints;
using Workloads.Features.Models;

namespace Workloads.Features.Workloads.GetWorkloadsByEmployee;

public sealed class GetWorkloadsByEmployeeMappers
  : Mapper<GetWorkloadsByEmployeeRequest, GetWorkloadsByEmployeeResponse, IEnumerable<Workload>>
{
  public sealed override GetWorkloadsByEmployeeResponse FromEntity(IEnumerable<Workload> workloads)
  {
    return new GetWorkloadsByEmployeeResponse(workloads.Select(workload => new GetWorkloadsByCustomerResponseItem
    (
      workload.Id,
      workload.EmployeeId,
      workload.CustomerId,
      workload.Start,
      workload.Stop,
      workload.Notes,
      workload.Customer,
      workload.Employee
    )).ToList());
  }
}