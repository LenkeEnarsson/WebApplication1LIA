using FluentValidation;

namespace Customers.Features.Customers.CreateCustomer;

public class CreateCustomerValidation
    : AbstractValidator<CreateCustomerRequest>
{
    public CreateCustomerValidation()
    {
        RuleFor(x => x.CompanyName).NotEmpty().WithMessage("Company name is required.");
    }
}