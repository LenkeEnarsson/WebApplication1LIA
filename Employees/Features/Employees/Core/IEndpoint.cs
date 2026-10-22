using Microsoft.AspNetCore.Routing;

namespace Employees.Features.Employees.Core;

public interface IEndpoint
{
  IEndpointRouteBuilder SetupEndpoint(IEndpointRouteBuilder endpoints);
}