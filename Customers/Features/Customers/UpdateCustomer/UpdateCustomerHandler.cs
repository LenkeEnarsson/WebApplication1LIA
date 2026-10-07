using Common;
using Customers.Features.Customers.Core;

namespace Customers.Features.Customers.UpdateCustomer
{
    public sealed class UpdateCustomerHandler(IUpdateCustomerService customerUpdateService)
    : IRequestHandler<UpdateCustomerRequest, UpdateCustomerResponse>
    {
        public async Task<Result<UpdateCustomerResponse>> HandleAsync(UpdateCustomerRequest request)
        {
            var customer = await customerUpdateService.Update(request.ToCustomer());
            return Result.Success(customer.ToUpdateCustomerResponse());
        }
    }
}