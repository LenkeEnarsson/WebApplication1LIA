using Employees.Features.Employees.Models;

namespace Employees.Features.Employees.GetEmployee;

public interface IGetEmployeeService
{
  Task<Employee?> GetEmployeeAsync(Guid EmployeeId, CancellationToken cancellationToken);
}