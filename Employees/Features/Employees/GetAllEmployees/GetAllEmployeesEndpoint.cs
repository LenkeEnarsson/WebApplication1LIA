using FastEndpoints;

namespace WebApplication3.Features.Employees.GetAllEmployees;

internal sealed class GetAllEmployeesEndpoint 
  : EndpointWithoutRequest<GetAllEmployeesResponse, GetAllEmployeesMapper>
{
    public override void Configure()
    {
        Get("employee");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken cancellationToken)
    {
        var result = await new GetAllEmployeesRequest().ExecuteAsync(cancellationToken);

        await Send.OkAsync(result.Value, cancellationToken);
    }
}