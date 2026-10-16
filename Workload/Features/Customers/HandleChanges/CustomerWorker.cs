using Messaging.Abstract;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Workload.Features.Models;

namespace Workload.Features.Customers.HandleChanges;

public class CustomerWorker(ILogger<CustomerWorker> logger, IMessaging<CustomerContract> messaging, ICustomerEventService service)
  : BackgroundService
{

  protected override async Task ExecuteAsync(CancellationToken cancellationToken)
  {
    //DO NOT CALL INIT() HERE, IT WILL BE CALLED AUTOMATICALLY WHEN THE FIRST MESSAGE IS GOING TO BE SENT.
    await foreach (Message<CustomerContract> msg in messaging.ConsumeAsync(cancellationToken))
    {
      WorkloadCustomer customer = new()
      {
        Id = msg.Payload.Id,
        CompanyName = msg.Payload.CompanyName
      };
      switch (msg.Type)
      {
        case MessageType.Create:
          _ = await service.CreateCustomer(customer);
          break;
        case MessageType.Update:
          _ = await service.UpdateCustomer(customer);
          break;
        case MessageType.Delete:
          _ = await service.DeleteCustomer(customer);
          break;
      }
      logger.LogInformation("Recieved {operation} of customer: {CustomerId}", msg.Type, msg.Payload.Id);

    }
  }
}
