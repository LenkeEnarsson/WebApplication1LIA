using Common;
using FastEndpoints;

namespace Employees.Features.Employees.DeleteEmployee;

internal sealed class DeleteEmployeeEndpoint
  : Endpoint<DeleteEmployeeRequest, DeleteEmployeeResponse, DeleteEmployeeMapper>
{
  public override void Configure()
  {
    Delete("employee");
    AllowAnonymous();
  }

  public override async Task HandleAsync(DeleteEmployeeRequest request, CancellationToken cancellationToken)
  {
    Result<DeleteEmployeeResponse> result = await request.ExecuteAsync(cancellationToken);

    if (result.IsFailure)
    {
      _ = await Send.StringAsync(result.Error, statusCode: 400, cancellation: cancellationToken);
      return;
    }

    _ = await Send.OkAsync(result.Value, cancellationToken);
  }
}