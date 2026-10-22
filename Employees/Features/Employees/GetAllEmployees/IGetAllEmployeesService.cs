using Employees.Features.Employees.Models;

namespace Employees.Features.Employees.GetAllEmployees;

public interface IGetAllEmployeesService
{
  Task<IEnumerable<Employee>> GetAllEmployeesAsync(CancellationToken cancellationToken);
}