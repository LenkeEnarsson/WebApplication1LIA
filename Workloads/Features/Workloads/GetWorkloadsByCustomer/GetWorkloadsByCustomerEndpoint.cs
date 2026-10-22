using Common;
using FastEndpoints;

namespace Workloads.Features.Workloads.GetWorkloadsByCustomer;

internal sealed class GetWorkloadsByCustomerEndpoint
  : Endpoint<GetWorkloadsByCustomerRequest, GetWorkloadsByCustomerResponse, GetWorkloadsByCustomerMappers>
{
  public override void Configure()
  {
    Get("workloads/{Id}");
    AllowAnonymous();
  }

  public override async Task HandleAsync(GetWorkloadsByCustomerRequest request, CancellationToken cancellationToken)
  {
    Result<GetWorkloadsByCustomerResponse> response = await request.ExecuteAsync(cancellationToken);

    if (response.IsFailure)
    {
      await Send.NotFoundAsync(cancellationToken);
      return;
    }

    await Send.OkAsync(response.Value, cancellationToken);
  }
}