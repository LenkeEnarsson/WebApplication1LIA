using Employees.Features.Employees.Models;
using FastEndpoints;

namespace Employees.Features.Employees.DeleteEmployee;

internal sealed class DeleteEmployeeMapper
    : Mapper<DeleteEmployeeRequest, DeleteEmployeeResponse, Employee>
{
  public override DeleteEmployeeResponse FromEntity(Employee e)
  {
    return new DeleteEmployeeResponse(e.Id, e.SSID, e.Title, e.GivenName, e.Surname, e.Street, e.PostalCode, e.City, e.Phone);
  }
}