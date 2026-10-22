using Messaging.Abstract;
using Microsoft.Extensions.Logging;
using System.Runtime.CompilerServices;
using System.Threading.Channels;

namespace Messaging.Channels;

public class ChannelMessaging<T>(ILogger<ChannelMessaging<T>> logger) : IMessaging<T>
{
  private Channel<Message<T>>? channel = Channel.CreateUnbounded<Message<T>>();

  public Task Init()
  {
    return Task.CompletedTask;
  }

  public async IAsyncEnumerable<Message<T>> ConsumeAsync([EnumeratorCancellation] CancellationToken cancellationToken)
  {
    if (channel is not null)
    {
      await foreach (Message<T> msg in channel.Reader.ReadAllAsync(cancellationToken))
      {
        yield return msg;
      }
    }
  }

  public async Task PublishAsync(Message<T> message, CancellationToken cancellationToken)
  {
    cancellationToken.ThrowIfCancellationRequested();
    logger.LogInformation("Publishing: {MessageType} {PayloadType}", message.Type, message.Payload?.GetType());
    await channel.Writer.WriteAsync(message, cancellationToken);
  }

  public Task Done()
  {
    channel.Writer.Complete();
    return Task.CompletedTask;
  }
}