using Messaging.Abstract;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Messaging.Nats;

public static class NatsExtensions
{
  extension(IServiceCollection services)
  {
    public IServiceCollection AddNatsMessaging<T>(string subject)
    {
      services.AddSingleton<IMessaging<T>>(sp =>
        new NatsMessaging<T>(
          sp.GetRequiredService<ILogger<NatsMessaging<T>>>()
          , subject));
      return services;
    }
  }
}
