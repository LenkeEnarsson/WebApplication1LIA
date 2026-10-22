using FastEndpoints;
using Workloads.Features.Models;

namespace Workloads.Features.Workloads.StartWorkload;

internal sealed class StartWorkloadMapper
    : Mapper<StartWorkloadRequest, StartWorkloadResponse, Workload>
{
  public override Workload ToEntity(StartWorkloadRequest r)
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

  public override StartWorkloadResponse FromEntity(Workload w)
  {
    return new StartWorkloadResponse(
      w.Id,
      w.EmployeeId,
      w.CustomerId,
      w.Start,
      w.Notes,
      w.Customer,
      w.Employee
      );
  }
}