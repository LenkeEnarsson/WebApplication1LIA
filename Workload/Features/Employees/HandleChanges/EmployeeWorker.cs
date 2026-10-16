using Messaging.Abstract;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Workload.Features.Employees.HandleChanges;
using Workload.Features.Models;

namespace Workload.Features.Employees.HandleChanges;

public class EmployeeWorker(ILogger<EmployeeWorker> logger, IMessaging<EmployeeContract> messaging, IEmployeeEventService service)
  : BackgroundService
{

  protected override async Task ExecuteAsync(CancellationToken cancellationToken)
  {
    //DO NOT CALL INIT() HERE, IT WILL BE CALLED AUTOMATICALLY WHEN THE FIRST MESSAGE IS GOING TO BE SENT.
    await foreach (Message<EmployeeContract> msg in messaging.ConsumeAsync(cancellationToken))
    {
      WorkloadEmployee employee = new()
      {
        Id = msg.Payload.Id,
        GivenName = msg.Payload.GivenName,
        Surname = msg.Payload.Surname
      };
      switch (msg.Type)
      {
        case MessageType.Create:
          await service.CreateEmployee(employee);
          break;
        case MessageType.Update:
          await service.UpdateEmployee(employee);
          break;
        case MessageType.Delete:
          await service.DeleteEmployee(employee);
          break;
      }
      logger.LogInformation("Recieved {operation} of customer: {CustomerId}", msg.Type, msg.Payload.Id);

    }
  }
}

