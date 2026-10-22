using Workloads.Features.Models;
using Workloads.Features.WorkloadCustomers.GetAllWorkloadCustomers;
using Workloads.Features.WorkloadCustomers.HandleChanges;
using Workloads.Features.WorkloadEmployees.GetAllWorkloadEmployees;
using Workloads.Features.WorkloadEmployees.HandleChanges;
using Workloads.Features.Workloads.GetWorkloadsByCustomer;
using Workloads.Features.Workloads.GetWorkloadsByEmployee;
using Workloads.Features.Workloads.StartWorkload;
using Workloads.Features.Workloads.StopWorkload;

namespace Workloads.Infrastructure.Data.Services;

internal class WorkloadService
  : IWorkloadCustomerEventService, IWorkloadEmployeeEventService, IGetWorkloadsByCustomerService, IGetWorkloadsByEmployeeService, IStartWorkloadService, IStopWorkloadService, IGetAllWorkloadCustomersService, IGetAllWorkloadEmployeesService
{
  public Task<WorkloadCustomer> CreateCustomer(WorkloadCustomer customer, CancellationToken cancellationToken = default)
  {
    throw new NotImplementedException();
  }

  public Task<WorkloadEmployee> CreateEmployee(WorkloadEmployee employee, CancellationToken cancellationToken = default)
  {
    throw new NotImplementedException();
  }

  public Task<WorkloadCustomer> DeleteCustomer(WorkloadCustomer customer, CancellationToken cancellationToken = default)
  {
    throw new NotImplementedException();
  }

  public Task<WorkloadEmployee> DeleteEmployee(WorkloadEmployee employee, CancellationToken cancellationToken = default)
  {
    throw new NotImplementedException();
  }

  public Task<IEnumerable<WorkloadCustomer>> GetAllEmployeesAsync(CancellationToken cancellationToken)
  {
    throw new NotImplementedException();
  }

  public Task<IEnumerable<Workload>> GetWorkloadsByCustomerAsync(CancellationToken cancellationToken)
  {
    throw new NotImplementedException();
  }

  public Task<Workload> StartWorkloadAsync(Workload workload, CancellationToken cancellationToken)
  {
    throw new NotImplementedException();
  }

  public Task<WorkloadCustomer> UpdateCustomer(WorkloadCustomer customer, CancellationToken cancellationToken = default)
  {
    throw new NotImplementedException();
  }

  public Task<WorkloadEmployee> UpdateEmployee(WorkloadEmployee employee, CancellationToken cancellationToken = default)
  {
    throw new NotImplementedException();
  }

  public Task<Workload?> UpdateEmployeeAsync(Workload workload, CancellationToken cancellationToken)
  {
    throw new NotImplementedException();
  }

  Task<IEnumerable<WorkloadEmployee>> IGetAllWorkloadEmployeesService.GetAllEmployeesAsync(CancellationToken cancellationToken)
  {
    throw new NotImplementedException();
  }
}