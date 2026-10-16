using Common;
using FastEndpoints;
using Messaging.Abstract;
using WebApplication3.Features.Employees.DeleteEmployee;
using WebApplication3.Features.Employees.Models;

namespace Employees.Features.Employees.DeleteEmployee;

internal sealed class DeleteEmployeeHandler(DeleteEmployeeMapper mapper, IDeleteEmployeeService service, IMessaging<Employee> messaging)
    : ICommandHandler<DeleteEmployeeRequest, Result<DeleteEmployeeResponse>>
{
  public async Task<Result<DeleteEmployeeResponse>> ExecuteAsync(DeleteEmployeeRequest request, CancellationToken cancellationToken)
  {
    Employee? employee = await service.DeleteEmployeeAsync(request.Id, cancellationToken);

    if (employee is null)
    {
      return Result.Failure<DeleteEmployeeResponse>($"Employee with id '{request.Id}' was not found.");
    }

    await messaging.PublishAsync(new Message<Employee>(MessageType.Delete, employee), cancellationToken);

    return Result.Success(mapper.FromEntity(employee));
  }
}
