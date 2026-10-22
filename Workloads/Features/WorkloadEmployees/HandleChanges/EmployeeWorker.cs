using Messaging.Abstract;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Workloads.Features.Models;

namespace Workloads.Features.WorkloadEmployees.HandleChanges;

public class EmployeeWorker(ILogger<EmployeeWorker> logger, IMessaging<EmployeeContract> messaging, IWorkloadEmployeeEventService service)
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
        FirstName = msg.Payload.GivenName,
        LastName = msg.Payload.Surname
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