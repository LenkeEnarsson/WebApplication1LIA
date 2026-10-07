using Common;
using Customers.Features.Customers.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Customers.Features.Customers.UpdateCustomer;

public sealed class UpdateCustomerEndpoint
: IEndpoint
{
    public IEndpointRouteBuilder SetupEndpoint(IEndpointRouteBuilder endpoints)
    {
        _ = endpoints.MapPut("/", async (UpdateCustomerRequest request, IRequestHandler<UpdateCustomerRequest, UpdateCustomerResponse> handler) =>
        {
            var result = await handler.HandleAsync(request);
            return result.ToMinimalApiResult(error => Results.BadRequest(new { error }));
        })
        .WithName("UpdateCustomer");
        return endpoints;
    }
}