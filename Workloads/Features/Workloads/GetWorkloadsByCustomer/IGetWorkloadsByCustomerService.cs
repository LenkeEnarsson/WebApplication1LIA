using Workloads.Features.Models;

namespace Workloads.Features.Workloads.GetWorkloadsByCustomer;

public interface IGetWorkloadsByCustomerService
{
  Task<IEnumerable<Workload>> GetWorkloadsByCustomerAsync(CancellationToken cancellationToken);
}