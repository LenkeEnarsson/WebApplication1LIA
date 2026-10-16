using WebApplication3.Features.Employees.Models;

namespace WebApplication3.Features.Employees.DeleteEmployee;

public interface IDeleteEmployeeService
{
  Task<Employee?> DeleteEmployeeAsync(Guid id, CancellationToken cancellationToken);
}