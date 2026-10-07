using Customers.Features.Customers.Core;
using Customers.Features.Customers.CreateCustomer;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Customers.Features.Customers.Extensions;

public static class HandlersExtensions
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddCustomersHandlers()
        {
            _ = services.AddValidatorsFromAssembly(typeof(CreateCustomerValidation).Assembly, ServiceLifetime.Scoped);

            IEnumerable<Type> handlerTypes = typeof(IRequestHandler<,>).Assembly
                .GetTypes()
                .Where(type => type is { IsClass: true, IsAbstract: false });

            foreach (Type? handlerType in handlerTypes)
            {
                IEnumerable<Type> handlerInterfaces = handlerType
                    .GetInterfaces()
                    .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IRequestHandler<,>));

                foreach (Type? handlerInterface in handlerInterfaces)
                {
                    _ = services.AddScoped(handlerInterface, handlerType);
                }
            }

            return services;
        }
    }
}