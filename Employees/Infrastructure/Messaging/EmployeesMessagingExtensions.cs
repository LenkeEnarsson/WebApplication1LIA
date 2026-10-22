using global::Messaging.Abstract;
using global::Messaging.Channels;
using Microsoft.Extensions.DependencyInjection;

namespace Employees.Infrastructure.Messaging;

public static class EmployeesMessagingExtensions
{
  extension(IServiceCollection services)
  {
    public IServiceCollection AddEmployeeMessaging()
    {
      _ = services.AddSingleton<IMessaging<EmployeeContract>, ChannelMessaging<EmployeeContract>>();
      return services;

      /*
      if(Environment.GetEnvironmentVariable("ISMONOLITH")=="true")
        services.AddMessagingChannels()
          else
      {
        services.AddMessagingNats()
      }
      */
    }
  }
}