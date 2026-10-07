using Common;
using Customers.Features.Customers.Core;
using Customers.Features.Customers.GetCustomer;
using Customers.Features.Customers.Model;

namespace Customers.Features.Customers.DeleteCustomer;

public sealed class DeleteCustomerHandler(IDeleteCustomerService customerDeleteService)
: IRequestHandler<DeleteCustomerRequest, DeleteCustomerResponse>
{
    public async Task<Result<DeleteCustomerResponse>> HandleAsync(DeleteCustomerRequest request)
    {
        Customer? customer = await customerDeleteService.Delete(request.Id);

        return customer is null
        ? Result.Failure<DeleteCustomerResponse>($"Customer with id '{request.Id}' was not found.")
        : Result.Success(customer.ToDeleteCustomerResponse());
    }
}