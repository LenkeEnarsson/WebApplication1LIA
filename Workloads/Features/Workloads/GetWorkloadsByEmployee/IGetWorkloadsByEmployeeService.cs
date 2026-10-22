using Workloads.Features.Models;

namespace Workloads.Features.Workloads.GetWorkloadsByEmployee;

public interface IGetWorkloadsByEmployeeService
{
  Task<IEnumerable<Workload>> GetWorkloadsByCustomerAsync(CancellationToken cancellationToken);
}