using Employees.Features.Employees.Models;
using FastEndpoints;

namespace Employees.Features.Employees.GetAllEmployees;

public sealed class GetAllEmployeesMapper
  : Mapper<GetAllEmployeesRequest, GetAllEmployeesResponse, IEnumerable<Employee>>
{
  public override GetAllEmployeesResponse FromEntity(IEnumerable<Employee> employees)
  {
    return new GetAllEmployeesResponse(employees.Select(employee => new GetAllEmployeesResponseItem
    (
      employee.Id,
      employee.SSID,
      employee.Title,
      employee.GivenName,
      employee.Surname,
      employee.Street,
      employee.PostalCode,
      employee.City,
      employee.Phone
    )).ToList());
  }
}