using Messaging.Abstract;
using Messaging.Channels;
using Microsoft.Extensions.DependencyInjection;

namespace Workloads.Infrastructure.Messaging;

public static class WorkloadsMessagingExtensions
{
  extension(IServiceCollection services)
  {
    public IServiceCollection AddWorkloadsMessaging()
    {

      _ = services.AddSingleton<IMessaging<WorkloadContract>, ChannelMessaging<WorkloadContract>>();
      return services;
    }
  }
}
