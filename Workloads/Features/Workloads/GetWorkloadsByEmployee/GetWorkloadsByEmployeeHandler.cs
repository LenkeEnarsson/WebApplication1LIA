using Common;
using FastEndpoints;
using Workloads.Features.Models;

namespace Workloads.Features.Workloads.GetWorkloadsByEmployee;


internal sealed class GetWorkloadsByEmployeeHandler(GetWorkloadsByEmployeeMappers mapper, IGetWorkloadsByEmployeeService service)
    : ICommandHandler<GetWorkloadsByEmployeeRequest, Result<GetWorkloadsByEmployeeResponse>>
{
  public async Task<Result<GetWorkloadsByEmployeeResponse>> ExecuteAsync(GetWorkloadsByEmployeeRequest request, CancellationToken cancellationToken)
  {
    IEnumerable<Workload>? response = await service.GetWorkloadsByCustomerAsync(cancellationToken);
    return response is null
  ? Result.Failure<GetWorkloadsByEmployeeResponse>("Fetching failed.")
  : Result.Success(mapper.FromEntity(response));
  }
}