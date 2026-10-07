using FluentValidation;
using Common;
using Customers.Features.Customers.Core;

namespace Customers.Features.Customers.CreateCustomer
{
    public sealed class CreateCustomerHandler(ICreateCustomerService customerCreateService, IValidator<CreateCustomerRequest> validator)
        : IRequestHandler<CreateCustomerRequest, CreateCustomerResponse>
    {
        public async Task<Result<CreateCustomerResponse>> HandleAsync(CreateCustomerRequest request)
        {
            var validationResult = await validator.ValidateAsync(request);
            if (!validationResult.IsValid)
                return Result.Failure<CreateCustomerResponse>(string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage)));

            var customer = await customerCreateService.Create(request.ToCustomer());
            return Result.Success(customer.ToCreateCustomerResponse());
        }
    }
}