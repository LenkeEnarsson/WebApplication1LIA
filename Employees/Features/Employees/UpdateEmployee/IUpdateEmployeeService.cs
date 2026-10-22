using Employees.Features.Employees.Models;

namespace Employees.Features.Employees.UpdateEmployee;

public interface IUpdateEmployeeService
{
  Task<Employee?> UpdateEmployeeAsync(Employee employee, CancellationToken cancellationToken);
}