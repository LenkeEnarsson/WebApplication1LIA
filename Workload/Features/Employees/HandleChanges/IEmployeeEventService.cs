using System;
using System.Collections.Generic;
using System.Text;
using Workload.Features.Models;

namespace Workload.Features.Employees.HandleChanges;

public interface IEmployeeEventService
{
  Task<WorkLoadEmployee> CreateEmployee(WorkloadEmployee employee, CancellationToken cancellationToken = default);
  Task<WorkLoadEmployee> UpdateEmployee(WorkloadEmployee employee, CancellationToken cancellationToken = default);
  Task<WorkLoadEmployee> DeleteEmployee(WorkloadEmployee employee, CancellationToken cancellationToken = default);
}
