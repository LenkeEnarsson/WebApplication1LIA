using FastEndpoints;

namespace Workloads.Features.WorkloadEmployees.GetAllWorkloadEmployees;

internal sealed class GetAllWorkloadEmployeesEndpoint
  : EndpointWithoutRequest<GetAllWorkloadEmployeesResponse, GetAllWorkloadEmployeesMappers>
{
  public override void Configure()
  {
    Get("workloads");
    AllowAnonymous();
  }

  public override async Task HandleAsync(CancellationToken cancellationToken)
  {
    var result = await new GetAllWorkloadEmployeesRequest().ExecuteAsync(cancellationToken);

    await Send.OkAsync(result.Value, cancellationToken);
  }
}