using Workloads.Features.Models;

namespace Workloads.Features.WorkloadEmployees.GetAllWorkloadEmployees;

public interface IGetAllWorkloadEmployeesService
{
  Task<IEnumerable<WorkloadEmployee>> GetAllEmployeesAsync(CancellationToken cancellationToken);
}