using Common;
using FastEndpoints;

namespace Employees.Features.Employees.GetEmployee;

public sealed class GetEmployeeRequest
    : ICommand<Result<GetEmployeeResponse>>
{
  public required Guid Id { get; set; }

}
