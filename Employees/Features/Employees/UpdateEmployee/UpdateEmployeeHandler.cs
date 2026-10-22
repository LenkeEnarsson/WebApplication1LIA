using Common;
using Employees.Features.Employees.Models;
using FastEndpoints;
using Messaging.Abstract;

namespace Employees.Features.Employees.UpdateEmployee;

public sealed class UpdateEmployeeHandler(UpdateEmployeeMapper mapper, IUpdateEmployeeService service, IMessaging<Employee> messaging)
    : ICommandHandler<UpdateEmployeeRequest, Result<UpdateEmployeeResponse>>
{
  public async Task<Result<UpdateEmployeeResponse>> ExecuteAsync(UpdateEmployeeRequest command, CancellationToken cancellationToken)
  {
    var employee = await service.UpdateEmployeeAsync(mapper.ToEntity(command), cancellationToken);

    if (employee is null)
      return Result.Failure<UpdateEmployeeResponse>($"Employee with id '{command.Id}' was not found.");

    await messaging.PublishAsync(new Message<Employee>(MessageType.Update, employee), cancellationToken);
    return Result.Success(mapper.FromEntity(employee));
  }
}