using FluentValidation;

namespace Customers.Features.Customers.UpdateCustomer;

public class UpdateCustomerValidation
    : AbstractValidator<UpdateCustomerRequest>
{
  public UpdateCustomerValidation()
  {
    RuleFor(x => x.CompanyName).NotEmpty().WithMessage("Company name is required.");
    RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required.");
  }
}