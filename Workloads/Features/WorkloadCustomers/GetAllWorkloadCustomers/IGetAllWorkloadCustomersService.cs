using Workloads.Features.Models;

namespace Workloads.Features.WorkloadCustomers.GetAllWorkloadCustomers;

public interface IGetAllWorkloadCustomersService
{
  Task<IEnumerable<WorkloadCustomer>> GetAllEmployeesAsync(CancellationToken cancellationToken);
}