using FastEndpoints;

namespace Workloads.Features.WorkloadCustomers.GetAllWorkloadCustomers;

internal sealed class GetAllWorkloadCustomersEndpoint
  : EndpointWithoutRequest<GetAllWorkloadCustomersResponse, GetAllWorkloadCustomersMappers>
{
  public override void Configure()
  {
    Get("workloads");
    AllowAnonymous();
  }

  public override async Task HandleAsync(CancellationToken cancellationToken)
  {
    var result = await new GetAllWorkloadCustomersRequest().ExecuteAsync(cancellationToken);

    await Send.OkAsync(result.Value, cancellationToken);
  }
}