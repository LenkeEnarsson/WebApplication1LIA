using Common;
using FastEndpoints;
using Workloads.Features.Models;

namespace Workloads.Features.Workloads.GetWorkloadsByCustomer;


internal sealed class GetWorkloadsByCustomerHandler(GetWorkloadsByCustomerMappers mapper, IGetWorkloadsByCustomerService service)
    : ICommandHandler<GetWorkloadsByCustomerRequest, Result<GetWorkloadsByCustomerResponse>>
{
  public async Task<Result<GetWorkloadsByCustomerResponse>> ExecuteAsync(GetWorkloadsByCustomerRequest request, CancellationToken cancellationToken)
  {
    IEnumerable<Workload>? response = await service.GetWorkloadsByCustomerAsync(cancellationToken);
    return response is null
  ? Result.Failure<GetWorkloadsByCustomerResponse>("Fetching failed.")
  : Result.Success(mapper.FromEntity(response));
  }
}