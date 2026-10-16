using WebApplication3.Features.Employees.Models;

namespace WebApplication3.Features.Employees.UpdateEmployee;

public interface IUpdateEmployeeService
{
    Task<Employee?> UpdateEmployeeAsync(Employee employee, CancellationToken cancellationToken);
}