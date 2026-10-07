using Common;
using Customers.Features.Customers.Core;
using Customers.Features.Customers.GetAllCustomer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Customers.Features.Customers.GetCustomer;

public sealed class GetCustomerEndpoint
: IEndpoint
{
    public IEndpointRouteBuilder SetupEndpoint(IEndpointRouteBuilder endpoints)
    {
        _ = endpoints.MapGet("/{id}", async (Guid id, IRequestHandler<GetCustomerRequest, GetAllCustomersResponse> handler) =>
        {
            var result = await handler.HandleAsync(new GetCustomerRequest(id));
            return result.ToMinimalApiResult(error => Results.NotFound(new { error }));
        })
            .WithName("GetCustomer");
        return endpoints;
    }
}