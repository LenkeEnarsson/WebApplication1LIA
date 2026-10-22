using FastEndpoints;
using Workloads.Features.Models;

namespace Workloads.Features.WorkloadEmployees.GetAllWorkloadEmployees;

public sealed class GetAllWorkloadEmployeesMappers
  : Mapper<GetAllWorkloadEmployeesRequest, GetAllWorkloadEmployeesResponse, IEnumerable<WorkloadEmployee>>
{
  public override GetAllWorkloadEmployeesResponse FromEntity(IEnumerable<WorkloadEmployee> employees)
  {
    return new GetAllWorkloadEmployeesResponse(employees.Select(employee => new GetAllWorkloadEmployeesResponseItem
    (
      employee.Id,
      employee.FirstName,
      employee.LastName
    )).ToList());
  }
}