using Common;
using Employees.Features.Employees.Models;
using FastEndpoints;

namespace Employees.Features.Employees.GetEmployee;

internal sealed class GetEmployeeHandler(GetEmployeeMapper mapper, IGetEmployeeService service)
    : ICommandHandler<GetEmployeeRequest, Result<GetEmployeeResponse>>
{
  public async Task<Result<GetEmployeeResponse>> ExecuteAsync(GetEmployeeRequest request, CancellationToken ct)
  {
    Employee? employee = await service.GetEmployeeAsync(request.Id, ct);
    return employee is null
      ? Result.Failure<GetEmployeeResponse>($"Employee with id '{request.Id}' was not found.")
      : Result.Success(mapper.FromEntity(employee));
  }
}