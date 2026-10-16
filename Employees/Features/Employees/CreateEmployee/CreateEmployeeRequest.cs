using Common;
using Employees.Features.Employees.Validation;
using FastEndpoints;
using FluentValidation;

namespace Employees.Features.Employees.CreateEmployee;

public sealed class CreateEmployeeRequest
    : ICommand<Result<CreateEmployeeResponse>>
{
  public string SSID { get; set; } = string.Empty;
  public string Title { get; set; } = string.Empty;
  public string GivenName { get; set; } = string.Empty;
  public string Surname { get; set; } = string.Empty;
  public string Street { get; set; } = string.Empty;
  public string PostalCode { get; set; } = string.Empty;
  public string City { get; set; } = string.Empty;
  public string Phone { get; set; } = string.Empty;

  public sealed class Validator : Validator<CreateEmployeeRequest>
  {
    public Validator()
    {
      _ = RuleFor(x => x.SSID)
      .NotEmpty().WithMessage("SSID is required.")
      .Must(SwedishPersonalIdentityNumberValidator.IsValid).WithMessage("SSID must be a valid Swedish personal identity number.");
      _ = RuleFor(x => x.Title).NotEmpty().WithMessage("Title is required.");
      _ = RuleFor(x => x.GivenName).NotEmpty().WithMessage("Given name is required.");
      _ = RuleFor(x => x.Surname).NotEmpty().WithMessage("Surname is required.");
      _ = RuleFor(x => x.Street).NotEmpty().WithMessage("Street is required.");
      _ = RuleFor(x => x.PostalCode).NotEmpty().WithMessage("Postal code is required.");
      _ = RuleFor(x => x.City).NotEmpty().WithMessage("City is required.");
      _ = RuleFor(x => x.Phone).NotEmpty().WithMessage("Phone is required.");
    }
  }
}
