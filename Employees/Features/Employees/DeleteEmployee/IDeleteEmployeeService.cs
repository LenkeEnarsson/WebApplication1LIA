using Employees.Features.Employees.Models;

namespace Employees.Features.Employees.DeleteEmployee;

public interface IDeleteEmployeeService
{
  Task<Employee?> DeleteEmployeeAsync(Guid id, CancellationToken cancellationToken);
}