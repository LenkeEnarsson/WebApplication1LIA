using Employees.Features.Employees.Models;
using Messaging.Abstract;

namespace Employees.Features.Employees.Mappers;

internal static class EmployeeToContractExtension
{
  extension(Employee employee)
  {
    public EmployeeContract ToContract()
    {
      return new EmployeeContract(
        employee.Id,
        employee.Title,
        employee.GivenName,
        employee.Surname,
        employee.Street,
        employee.PostalCode,
        employee.City,
        employee.Phone
      );
    }
  }
}
