using Common;
using FastEndpoints;
using Workloads.Features.Models;

namespace Workloads.Features.WorkloadCustomers.GetAllWorkloadCustomers;


internal sealed class GetAllWorkloadCustomersHandler(GetAllWorkloadCustomersMappers mapper, IGetAllWorkloadCustomersService service)
    : ICommandHandler<GetAllWorkloadCustomersRequest, Result<GetAllWorkloadCustomersResponse>>
{
  public async Task<Result<GetAllWorkloadCustomersResponse>> ExecuteAsync(GetAllWorkloadCustomersRequest request, CancellationToken cancellationToken)
  {
    IEnumerable<WorkloadCustomer>? response = await service.GetAllEmployeesAsync(cancellationToken);
    return response is null
  ? Result.Failure<GetAllWorkloadCustomersResponse>("Fetching failed.")
  : Result.Success(mapper.FromEntity(response));
  }
}