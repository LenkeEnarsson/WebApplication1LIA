using Employees.Features.Employees.CreateEmployee;
using Employees.Features.Employees.DeleteEmployee;
using Employees.Features.Employees.GetAllEmployees;
using Employees.Features.Employees.GetEmployee;
using Employees.Features.Employees.Models;
using Employees.Features.Employees.UpdateEmployee;
using Employees.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Employees.Infrastructure.Data.Services;

public sealed class EmployeeService(EmployeesContext employeeContext)
    : ICreateEmployeeService, IGetEmployeeService, IGetAllEmployeesService, IUpdateEmployeeService, IDeleteEmployeeService
{
  public async Task<Employee> CreateEmployeeAsync(Employee employee, CancellationToken cancellationToken)
  {
    _ = employeeContext.Employees.Add(employee);
    await employeeContext.SaveChangesAsync(cancellationToken);

    return employee;
  }

  public Task<Employee?> GetEmployeeAsync(Guid id, CancellationToken cancellationToken)
  {
    return Task.FromResult(employeeContext.Employees.AsNoTracking().FirstOrDefault(e => e.Id == id));
  }

  public Task<IEnumerable<Employee>> GetAllEmployeesAsync(CancellationToken cancellationToken)
  {
    return Task.FromResult(employeeContext.Employees.AsNoTracking().AsEnumerable());
  }

  public async Task<Employee?> UpdateEmployeeAsync(Employee employee, CancellationToken cancellationToken)
  {
    var existing = employeeContext.Employees.FirstOrDefault(e => e.Id == employee.Id);
    if (existing is null)
      return null;

    existing.SSID = employee.SSID;
    existing.Title = employee.Title;
    existing.GivenName = employee.GivenName;
    existing.Surname = employee.Surname;
    existing.Street = employee.Street;
    existing.PostalCode = employee.PostalCode;
    existing.City = employee.City;
    existing.Phone = employee.Phone;
    await employeeContext.SaveChangesAsync(cancellationToken);
    return existing;
  }

  public async Task<Employee?> DeleteEmployeeAsync(Guid id, CancellationToken cancellationToken)
  {
    var employee = employeeContext.Employees.FirstOrDefault(e => e.Id == id);
    if (employee is null)
      return null;

    employeeContext.Remove(employee);
    await employeeContext.SaveChangesAsync(cancellationToken);
    return employee;
  }
}