using FastEndpoints;
using Workloads.Features.Models;

namespace Workloads.Features.WorkloadCustomers.GetAllWorkloadCustomers;

public sealed class GetAllWorkloadCustomersMappers
  : Mapper<GetAllWorkloadCustomersRequest, GetAllWorkloadCustomersResponse, IEnumerable<WorkloadCustomer>>
{
  public override GetAllWorkloadCustomersResponse FromEntity(IEnumerable<WorkloadCustomer> customers)
  {
    return new GetAllWorkloadCustomersResponse(customers.Select(customer => new GetAllWorkloadCustomersResponseItem
    (
      customer.Id,
      customer.CompanyName
    )).ToList());
  }
}