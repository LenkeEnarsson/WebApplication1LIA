using Microsoft.AspNetCore.Routing;

namespace Workloads.Features.Core;

public interface IEndpoint
{
  IEndpointRouteBuilder SetupEndpoint(IEndpointRouteBuilder endpoints);
}