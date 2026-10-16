using Common;
using Customers.Features.Customers.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Customers.Features.Customers.DeleteCustomer;

public sealed class DeleteCustomerEndpoint
: IEndpoint
{
    public IEndpointRouteBuilder SetupEndpoint(IEndpointRouteBuilder endpoints)
    {
    _ = endpoints.MapDelete("/{id}", async (Guid id, IRequestHandler<DeleteCustomerRequest, DeleteCustomerResponse> handler) =>
    {
      var result = await handler.HandleAsync(new DeleteCustomerRequest(id));
      return result.ToMinimalApiResult(error => Results.NotFound(new { error }));
    })
      .Produces<DeleteCustomerResponse>()
            .WithName("DeleteCustomer");
        return endpoints;
    }
}