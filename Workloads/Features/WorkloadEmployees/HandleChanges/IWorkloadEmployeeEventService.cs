using Workloads.Features.Models;

namespace Workloads.Features.WorkloadEmployees.HandleChanges;

public interface IWorkloadEmployeeEventService
{
  Task<WorkloadEmployee> CreateEmployee(WorkloadEmployee employee, CancellationToken cancellationToken = default);

  Task<WorkloadEmployee> UpdateEmployee(WorkloadEmployee employee, CancellationToken cancellationToken = default);

  Task<WorkloadEmployee> DeleteEmployee(WorkloadEmployee employee, CancellationToken cancellationToken = default);
}