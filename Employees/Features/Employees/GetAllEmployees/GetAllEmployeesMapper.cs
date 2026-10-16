using FastEndpoints;
using WebApplication3.Features.Employees.Models;

namespace WebApplication3.Features.Employees.GetAllEmployees;


public sealed class GetAllEmployeesMapper
  : Mapper<GetAllEmployeesRequest, GetAllEmployeesResponse, IEnumerable<Employee>>
{
  public override GetAllEmployeesResponse FromEntity(IEnumerable<Employee> employees)
  {
    return new GetAllEmployeesResponse(employees.Select(employee => new GetAllEmployeesResponseItem
    (
      employee.Id,
      employee.GivenName,
      employee.Surname
    )).ToList());
  }
}