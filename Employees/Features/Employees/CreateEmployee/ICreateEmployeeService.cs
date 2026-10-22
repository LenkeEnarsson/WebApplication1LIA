using Employees.Features.Employees.Models;

namespace Employees.Features.Employees.CreateEmployee;

public interface ICreateEmployeeService
{
  Task<Employee> CreateEmployeeAsync(Employee employee, CancellationToken cancellationToken);
}