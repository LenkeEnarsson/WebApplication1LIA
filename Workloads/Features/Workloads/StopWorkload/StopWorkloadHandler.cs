using Common;
using FastEndpoints;
using Messaging.Abstract;
using Workloads.Features.Models;
using Workloads.Features.Workloads.Mappers;

namespace Workloads.Features.Workloads.StopWorkload;

public sealed class StopWorkloadHandler(StopWorkloadMapper mapper, IStopWorkloadService service, IMessaging<WorkloadContract> messaging)
    : ICommandHandler<StopWorkloadRequest, Result<StopWorkloadResponse>>
{
  public async Task<Result<StopWorkloadResponse>> ExecuteAsync(StopWorkloadRequest request, CancellationToken cancellationToken)
  {
    var workload = await service.UpdateEmployeeAsync(mapper.ToEntity(request), cancellationToken);

    if (workload is null)
      return Result.Failure<StopWorkloadResponse>($"Workload with id '{request.Id}' was not found.");

    await messaging.PublishAsync(new Message<WorkloadContract>(MessageType.Update, workload.ToContract()), cancellationToken);
    return Result.Success(mapper.FromEntity(workload));
  }
}