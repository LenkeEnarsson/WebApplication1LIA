using Common;
using FastEndpoints;
using Messaging.Abstract;
using WebApplication3.Features.Employees.Models;
using WebApplication3.Features.Employees.UpdateEmployee;

namespace Employees.Features.Employees.UpdateEmployee;

internal sealed class UpdateEmployeeHandler(UpdateEmployeeMapper mapper, IUpdateEmployeeService service, IMessaging<Employee> messaging)
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