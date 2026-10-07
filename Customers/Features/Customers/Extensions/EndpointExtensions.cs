using Customers.Features.Customers.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace Customers.Features.Customers.Extensions;

public static class EndpointExtensions
{
    extension(IEndpointRouteBuilder app)
    {
        public IEndpointRouteBuilder MapCustomersEndpoints()
        {
            RouteGroupBuilder group = app.MapGroup("/customers");

            IEnumerable<Type> endpointTypes = typeof(IEndpoint).Assembly
                .GetTypes()
                .Where(type => type is { IsClass: true, IsAbstract: false } && typeof(IEndpoint).IsAssignableFrom(type));

            foreach (Type? endpointType in endpointTypes)
            {
                var endpoint = (IEndpoint)Activator.CreateInstance(endpointType)!;
                _ = endpoint.SetupEndpoint(group);
            }

            return app;
        }

        //Kan automatisera grupper också, abstrahera ytterligare ett lager med generics genom reflections.
    }
}