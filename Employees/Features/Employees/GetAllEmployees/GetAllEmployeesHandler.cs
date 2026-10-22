using Common;
using Employees.Features.Employees.Models;
using FastEndpoints;

namespace Employees.Features.Employees.GetAllEmployees;

internal sealed class GetAllEmployeesHandler(GetAllEmployeesMapper mapper, IGetAllEmployeesService service)
    : ICommandHandler<GetAllEmployeesRequest, Result<GetAllEmployeesResponse>>
{
  public async Task<Result<GetAllEmployeesResponse>> ExecuteAsync(GetAllEmployeesRequest request, CancellationToken cancellationToken)
  {
    IEnumerable<Employee>? response = await service.GetAllEmployeesAsync(cancellationToken);
    return response is null
  ? Result.Failure<GetAllEmployeesResponse>("Fetching failed.")
  : Result.Success(mapper.FromEntity(response));
  }
}