using Common;
using FastEndpoints;
using Messaging.Abstract;
using Workloads.Features.Models;
using Workloads.Features.Workloads.Mappers;

namespace Workloads.Features.Workloads.StartWorkload;

internal class StartWorkloadHandler(StartWorkloadMapper mapper, IStartWorkloadService service, IMessaging<WorkloadContract> messaging)
    : ICommandHandler<StartWorkloadRequest, Result<StartWorkloadResponse>>
{
  public async Task<Result<StartWorkloadResponse>> ExecuteAsync(StartWorkloadRequest request, CancellationToken cancellationToken)
  {
    Workload workload = mapper.ToEntity(request);
    workload = await service.StartWorkloadAsync(workload, cancellationToken);

    var message = new Message<WorkloadContract>(MessageType.Create, workload.ToContract());
    await messaging.PublishAsync(message, cancellationToken);

    return workload is null
      ? Result.Failure<StartWorkloadResponse>("Workload start failed.")
      : Result.Success(mapper.FromEntity(workload));
  }
}