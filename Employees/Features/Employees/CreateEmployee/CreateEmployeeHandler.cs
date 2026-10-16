using Common;
using FastEndpoints;
using Messaging.Abstract;
using WebApplication3.Features.Employees.CreateEmployee;
using WebApplication3.Features.Employees.Models;

namespace Employees.Features.Employees.CreateEmployee;

internal class CreateEmployeeHandler(CreateEmployeeMapper mapper, ICreateEmployeeService service, IMessaging<EmployeeContract> messaging)
    : ICommandHandler<CreateEmployeeRequest, Result<CreateEmployeeResponse>>
{
  public async Task<Result<CreateEmployeeResponse>> ExecuteAsync(CreateEmployeeRequest request, CancellationToken cancellationToken)
  {
    Employee employee = mapper.ToEntity(request);
    employee = await service.CreateEmployeeAsync(employee, cancellationToken);

    var message = new Message<EmployeeContract>(MessageType.Create, employee.ToContract());
    await messaging.PublishAsync(message, cancellationToken);

    return employee is null
      ? Result.Failure<CreateEmployeeResponse>("Employee creation failed.")
      : Result.Success(mapper.FromEntity(employee));
  }
}
