using System;
using System.Collections.Generic;
using System.Text;
using Workload.Features.Customers.HandleChanges;
using Workload.Features.Employees.HandleChanges;
using Workload.Features.Models;

namespace Workload.Infrastructure.Data.Services;

internal class WorkloadService
  : ICustomerEventService, IEmployeeEventService
{
  public Task<WorkloadCustomer> CreateCustomer(WorkloadCustomer customer, CancellationToken cancellationToken = default)
  {
    throw new NotImplementedException();
  }

  public Task<WorkLoadEmployee> CreateEmployee(WorkloadEmployee employee, CancellationToken cancellationToken = default)
  {
    throw new NotImplementedException();
  }

  public Task<WorkloadCustomer> DeleteCustomer(WorkloadCustomer customer, CancellationToken cancellationToken = default)
  {
    throw new NotImplementedException();
  }

  public Task<WorkLoadEmployee> DeleteEmployee(WorkloadEmployee employee, CancellationToken cancellationToken = default)
  {
    throw new NotImplementedException();
  }

  public Task<WorkloadCustomer> UpdateCustomer(WorkloadCustomer customer, CancellationToken cancellationToken = default)
  {
    throw new NotImplementedException();
  }

  public Task<WorkLoadEmployee> UpdateEmployee(WorkloadEmployee employee, CancellationToken cancellationToken = default)
  {
    throw new NotImplementedException();
  }
}
