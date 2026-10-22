using Workloads.Features.Models;

namespace Workloads.Features.Workloads.StartWorkload;

public interface IStartWorkloadService
{
  Task<Workload> StartWorkloadAsync(Workload workload, CancellationToken cancellationToken);
}