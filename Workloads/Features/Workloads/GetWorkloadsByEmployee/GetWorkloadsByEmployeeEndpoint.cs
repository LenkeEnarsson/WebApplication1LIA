using Common;
using FastEndpoints;

namespace Workloads.Features.Workloads.GetWorkloadsByEmployee;

internal sealed class GetWorkloadsByEmployeeEndpoint
  : Endpoint<GetWorkloadsByEmployeeRequest, GetWorkloadsByEmployeeResponse, GetWorkloadsByEmployeeMappers>
{
  public override void Configure()
  {
    Get("workloads/{Id}");
    AllowAnonymous();
  }

  public override async Task HandleAsync(GetWorkloadsByEmployeeRequest request, CancellationToken cancellationToken)
  {
    Result<GetWorkloadsByEmployeeResponse> response = await request.ExecuteAsync(cancellationToken);

    if (response.IsFailure)
    {
      await Send.NotFoundAsync(cancellationToken);
      return;
    }

    await Send.OkAsync(response.Value, cancellationToken);
  }
}