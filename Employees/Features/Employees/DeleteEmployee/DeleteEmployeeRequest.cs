using Common;
using Employees.Features.Employees.DeleteEmployee;
using FastEndpoints;
using FluentValidation;

namespace WebApplication3.Features.Employees.DeleteEmployee;

public sealed class DeleteEmployeeRequest
    : ICommand<Result<DeleteEmployeeResponse>>
{
    public required Guid Id { get; set; }

    public sealed class Validator : Validator<DeleteEmployeeRequest>
    {
        public Validator()
        {
            _ = RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required");
        }
    }
}
