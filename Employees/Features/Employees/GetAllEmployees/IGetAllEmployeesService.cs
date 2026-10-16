using WebApplication3.Features.Employees.Models;

namespace WebApplication3.Features.Employees.GetAllEmployees;

public interface IGetAllEmployeesService
{
    Task<IEnumerable<Employee>> GetAllEmployeesAsync(CancellationToken cancellationToken);
}