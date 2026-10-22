using Workloads.Features.Models;

namespace Workloads.Features.Workloads.StopWorkload;


public interface IStopWorkloadService
{
  Task<Workload?> UpdateEmployeeAsync(Workload workload, CancellationToken cancellationToken);
}