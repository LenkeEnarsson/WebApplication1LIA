using Common;
using FastEndpoints;
using FluentValidation;

namespace Employees.Features.Employees.DeleteEmployee;

public sealed class DeleteEmployeeRequest
    : ICommand<Result<DeleteEmployeeResponse>>
{
  public Guid Id { get; set; }

  public sealed class Validator : Validator<DeleteEmployeeRequest>
  {
    public Validator()
    {
      _ = RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required");
    }
  }
}