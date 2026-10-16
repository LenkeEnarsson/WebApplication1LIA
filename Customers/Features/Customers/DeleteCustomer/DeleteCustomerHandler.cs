using Common;
using Customers.Features.Customers.Core;
using Customers.Features.Customers.Model;
using Messaging.Abstract;

namespace Customers.Features.Customers.DeleteCustomer;

public sealed class DeleteCustomerHandler(IDeleteCustomerService customerDeleteService, IMessaging<Customer> messaging)
: IRequestHandler<DeleteCustomerRequest, DeleteCustomerResponse>
{
  public async Task<Result<DeleteCustomerResponse>> HandleAsync(DeleteCustomerRequest request)
  {
    Customer? customer = await customerDeleteService.Delete(request.Id);

    if (customer is null)
    {
      return Result.Failure<DeleteCustomerResponse>($"Customer with id '{request.Id}' was not found.");
    }

    await messaging.PublishAsync(new Message<Customer>(MessageType.Delete, customer), CancellationToken.None);

    return Result.Success(customer.ToDeleteCustomerResponse());
  }
}