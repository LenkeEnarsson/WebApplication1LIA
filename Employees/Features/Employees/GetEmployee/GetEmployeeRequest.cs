using Common;
using FastEndpoints;

namespace Employees.Features.Employees.GetEmployee;

public sealed class GetEmployeeRequest
    : ICommand<Result<GetEmployeeResponse>>
{
  public Guid Id { get; set; }
}