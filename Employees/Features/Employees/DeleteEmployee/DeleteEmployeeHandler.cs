using Common;
using Employees.Features.Employees.Mappers;
using Employees.Features.Employees.Models;
using FastEndpoints;
using Messaging.Abstract;

namespace Employees.Features.Employees.DeleteEmployee;

internal sealed class DeleteEmployeeHandler(DeleteEmployeeMapper mapper, IDeleteEmployeeService service, IMessaging<EmployeeContract> messaging)
    : ICommandHandler<DeleteEmployeeRequest, Result<DeleteEmployeeResponse>>
{
  public async Task<Result<DeleteEmployeeResponse>> ExecuteAsync(DeleteEmployeeRequest request, CancellationToken cancellationToken)
  {
    Employee? employee = await service.DeleteEmployeeAsync(request.Id, cancellationToken);

    if (employee is null)
    {
      return Result.Failure<DeleteEmployeeResponse>($"Employee with id '{request.Id}' was not found.");
    }

    await messaging.PublishAsync(new Message<EmployeeContract>(MessageType.Delete, employee.ToContract()), cancellationToken);

    return Result.Success(mapper.FromEntity(employee));
  }
}