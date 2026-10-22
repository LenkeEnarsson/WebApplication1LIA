using Messaging.Abstract;
using Microsoft.Extensions.DependencyInjection;

namespace Messaging.Channels;

public static class ChannelExtensions
{
  extension(IServiceCollection services)
  {
    public IServiceCollection AddChannelMessaging<T>()
    {
      _ = services.AddSingleton<IMessaging<T>, ChannelMessaging<T>>();
      return services;
    }
  }
}
