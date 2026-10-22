using FastEndpoints;

namespace Workloads.Features.Workloads.StopWorkload;

internal sealed class StopWorkloadEndpoint
  : Endpoint<StopWorkloadRequest, StopWorkloadResponse, StopWorkloadMapper>
{
  public override void Configure()
  {
    Put("workload");
    AllowAnonymous();
  }

  public override async Task HandleAsync(StopWorkloadRequest request, CancellationToken cancellationToken)
  {
    var result = await request.ExecuteAsync(cancellationToken);

    if (result.IsFailure)
    {
      await Send.NotFoundAsync(cancellationToken);
      return;
    }
    await Send.OkAsync(result.Value, cancellationToken);
  }
}