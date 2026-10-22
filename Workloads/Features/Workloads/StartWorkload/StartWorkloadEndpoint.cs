using Common;
using FastEndpoints;

namespace Workloads.Features.Workloads.StartWorkload;

internal sealed class StartWorkloadEndpoint
  : Endpoint<StartWorkloadRequest, StartWorkloadResponse, StartWorkloadMapper>
{
  public override void Configure()
  {
    Post("workload");
    AllowAnonymous();
  }

  public override async Task HandleAsync(StartWorkloadRequest request, CancellationToken cancellationToken)
  {
    Result<StartWorkloadResponse> result = await request.ExecuteAsync(cancellationToken);

    if (result.IsFailure)
    {
      _ = await Send.ErrorsAsync(400, cancellationToken);
      return;
    }

    _ = await Send.OkAsync(result.Value, cancellationToken);
  }
}