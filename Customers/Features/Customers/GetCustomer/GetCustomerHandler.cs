using Common;
using Customers.Features.Customers.Core;

namespace Customers.Features.Customers.GetCustomer
{
    public sealed class GetCustomerHandler(IGetCustomerService customerReadService)
    : IRequestHandler<GetCustomerRequest, GetCustomerResponse>
    {
        public async Task<Result<GetCustomerResponse>> HandleAsync(GetCustomerRequest request)
        {
            var customer = await customerReadService.Get(request.Id);
            return customer is null
                ? Result.Failure<GetCustomerResponse>($"Customer with id '{request.Id}' was not found.")
                : Result.Success(customer.ToGetCustomerReponse());
        }
    }
}
