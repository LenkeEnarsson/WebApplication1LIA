using Common;
using FastEndpoints;
using WebApplication3.Features.Employees.GetEmployee;

namespace Employees.Features.Employees.GetEmployee;

internal sealed class GetEmployeeEndpoint
  : Endpoint<GetEmployeeRequest, GetEmployeeResponse, GetEmployeeMapper>
{
  public override void Configure()
  {
    Get("employee/{Id}");
    AllowAnonymous();
  }

  public override async Task HandleAsync(GetEmployeeRequest request, CancellationToken cancellationToken)
  {
    Result<GetEmployeeResponse> response = await request.ExecuteAsync(cancellationToken);

    if (response.IsFailure)
    {
      await Send.NotFoundAsync(cancellationToken);
      return;
    }

    _ = await Send.OkAsync(response.Value, cancellationToken);

  }
}