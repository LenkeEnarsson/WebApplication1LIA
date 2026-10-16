using WebApplication3.Features.Employees.Models;

namespace WebApplication3.Features.Employees.CreateEmployee;

public interface ICreateEmployeeService
{
    Task<Employee> CreateEmployeeAsync(Employee employee, CancellationToken cancellationToken);
}