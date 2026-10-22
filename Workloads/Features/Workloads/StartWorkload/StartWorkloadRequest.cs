using Common;
using FastEndpoints;
using FluentValidation;

namespace Workloads.Features.Workloads.StartWorkload;

public sealed class StartWorkloadRequest
    : ICommand<Result<StartWorkloadResponse>>
{
  public Guid Id { get; set; }
  public required Guid EmployeeId { get; set; }
  public required Guid CustomerId { get; set; }
  public required DateTimeOffset Start { get; set; }
  public DateTimeOffset? Stop { get; set; }
  public string Notes { get; set; } = string.Empty;

  public sealed class Validator : Validator<StartWorkloadRequest>
  {
    public Validator()
    {
      _ = RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required.");
      _ = RuleFor(x => x.EmployeeId).NotEmpty().WithMessage("Employee Id is required.");
      _ = RuleFor(x => x.CustomerId).NotEmpty().WithMessage("Customer Id is required.");
      _ = RuleFor(x => x.Start).NotEmpty().WithMessage("Start time is required.");
    }
  }
}