using Workloads.Features.Models;

namespace Workloads.Features.WorkloadCustomers.HandleChanges;

public interface IWorkloadCustomerEventService
{
  Task<WorkloadCustomer> CreateCustomer(WorkloadCustomer customer, CancellationToken cancellationToken = default);

  Task<WorkloadCustomer> UpdateCustomer(WorkloadCustomer customer, CancellationToken cancellationToken = default);

  Task<WorkloadCustomer> DeleteCustomer(WorkloadCustomer customer, CancellationToken cancellationToken = default);
}