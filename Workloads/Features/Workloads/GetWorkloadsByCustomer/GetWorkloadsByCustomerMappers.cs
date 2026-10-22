using FastEndpoints;
using Workloads.Features.Models;

namespace Workloads.Features.Workloads.GetWorkloadsByCustomer;

public sealed class GetWorkloadsByCustomerMappers
  : Mapper<GetWorkloadsByCustomerRequest, GetWorkloadsByCustomerResponse, IEnumerable<Workload>>
{
  public sealed override GetWorkloadsByCustomerResponse FromEntity(IEnumerable<Workload> workloads)
  {
    return new GetWorkloadsByCustomerResponse(workloads.Select(workload => new GetWorkloadsByCustomerResponseItem
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