using FastEndpoints;
using Workloads.Features.Models;

namespace Workloads.Features.Workloads.StopWorkload;

public sealed class StopWorkloadMapper
  : Mapper<StopWorkloadRequest, StopWorkloadResponse, Workload>
{
  public override Workload ToEntity(StopWorkloadRequest r)
  {
    return new Workload
    {
      Id = r.Id,
      EmployeeId = r.EmployeeId,
      CustomerId = r.CustomerId,
      Start = r.Start,
      Stop = r.Stop,
      Notes = r.Notes
    };
  }

  public override StopWorkloadResponse FromEntity(Workload w)
  {
    return new StopWorkloadResponse(
      w.Id,
      w.EmployeeId,
      w.CustomerId,
      w.Start,
      w.Stop,
      w.Notes,
      w.Customer,
      w.Employee
          );
  }
}