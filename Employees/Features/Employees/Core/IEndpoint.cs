using Microsoft.AspNetCore.Routing;

namespace Customers.Features.Employees.Core;

public interface IEndpoint
{
    IEndpointRouteBuilder SetupEndpoint(IEndpointRouteBuilder endpoints);
}