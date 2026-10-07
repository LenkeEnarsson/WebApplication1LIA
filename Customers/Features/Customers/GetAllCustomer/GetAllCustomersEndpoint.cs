using Common;
using Customers.Features.Customers.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Customers.Features.Customers.GetAllCustomer;

public sealed class GetAllCustomersEndpoint
: IEndpoint
{
    public IEndpointRouteBuilder SetupEndpoint(IEndpointRouteBuilder endpoints)
    {
        _ = endpoints.MapGet("/", async (IRequestHandler<GetAllCustomersRequest, GetAllCustomersResponse> handler) =>
        {
            var result = await handler.HandleAsync(new GetAllCustomersRequest());
            return result.ToMinimalApiResult(error => Results.NotFound(new { error }));
        })
        .WithName("GetAllCustomers");
        return endpoints;
    }
}