using Common;
using FastEndpoints;

namespace Employees.Features.Employees.CreateEmployee;

internal sealed class CreateEmployeeEndpoint
  : Endpoint<CreateEmployeeRequest, CreateEmployeeResponse, CreateEmployeeMapper>
{
  public override void Configure()
  {
    Post("employee");
    AllowAnonymous();
  }

  public override async Task HandleAsync(CreateEmployeeRequest request, CancellationToken cancellationToken)
  {
    Result<CreateEmployeeResponse> result = await request.ExecuteAsync(cancellationToken);

    if (result.IsFailure)
    {
      _ = await Send.ErrorsAsync(400, cancellationToken);
      return;
    }

    _ = await Send.OkAsync(result.Value, cancellationToken);
  }
}