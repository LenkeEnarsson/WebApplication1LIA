using Common;
using FastEndpoints;
using FluentValidation;

namespace Workloads.Features.Workloads.StopWorkload;

public sealed class StopWorkloadRequest
    : ICommand<Result<StopWorkloadResponse>>
{
  public Guid Id { get; set; }
  public required Guid EmployeeId { get; set; }
  public required Guid CustomerId { get; set; }
  public required DateTimeOffset Start { get; set; }
  public DateTimeOffset Stop { get; set; }
  public string Notes { get; set; } = string.Empty;

  public sealed class Validator : Validator<StopWorkloadRequest>
  {
    public Validator()
    {
      _ = RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required.");
      _ = RuleFor(x => x.EmployeeId).NotEmpty().WithMessage("Employee Id is required.");
      _ = RuleFor(x => x.CustomerId).NotEmpty().WithMessage("Customer Id is required.");
      _ = RuleFor(x => x.Start).NotEmpty().WithMessage("Start time is required.");
      _ = RuleFor(x => x.Stop).NotEmpty().WithMessage("Stop time is required.");
    }
  }
}