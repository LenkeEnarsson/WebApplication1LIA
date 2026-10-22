using Common;
using FastEndpoints;
using Workloads.Features.Models;

namespace Workloads.Features.WorkloadEmployees.GetAllWorkloadEmployees;


internal sealed class GetAllWorkloadEmployeesHandler(GetAllWorkloadEmployeesMappers mapper, IGetAllWorkloadEmployeesService service)
    : ICommandHandler<GetAllWorkloadEmployeesRequest, Result<GetAllWorkloadEmployeesResponse>>
{
  public async Task<Result<GetAllWorkloadEmployeesResponse>> ExecuteAsync(GetAllWorkloadEmployeesRequest request, CancellationToken cancellationToken)
  {
    IEnumerable<WorkloadEmployee>? response = await service.GetAllEmployeesAsync(cancellationToken);
    return response is null
  ? Result.Failure<GetAllWorkloadEmployeesResponse>("Fetching failed.")
  : Result.Success(mapper.FromEntity(response));
  }
}