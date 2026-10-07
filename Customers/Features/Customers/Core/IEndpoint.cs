using Microsoft.AspNetCore.Routing;

namespace Customers.Features.Customers.Core;

public interface IEndpoint
{
    IEndpointRouteBuilder SetupEndpoint(IEndpointRouteBuilder endpoints);
}