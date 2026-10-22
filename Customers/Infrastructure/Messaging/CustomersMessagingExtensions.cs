using Messaging.Abstract;
using Messaging.Channels;
using Microsoft.Extensions.DependencyInjection;

namespace Customers.Infrastructure.Messaging;

public static class CustomersMessagingExtensions
{
  extension(IServiceCollection services)
  {
    public IServiceCollection AddCustomersMessaging()
    {
      services.AddSingleton<IMessaging<CustomerContract>, ChannelMessaging<CustomerContract>>();
      return services;
    }
  }
}