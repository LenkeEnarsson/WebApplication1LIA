using Common;
using Customers.Features.Customers.Core;
using Customers.Features.Customers.Model;
using Messaging.Abstract;

namespace Customers.Features.Customers.UpdateCustomer;

public sealed class UpdateCustomerHandler(IUpdateCustomerService customerUpdateService, IMessaging<Customer> messaging)
: IRequestHandler<UpdateCustomerRequest, UpdateCustomerResponse>
{
  public async Task<Result<UpdateCustomerResponse>> HandleAsync(UpdateCustomerRequest request)
  {
    Customer customer = await customerUpdateService.Update(request.ToCustomer());
    if (customer is null)
    {
      return Result.Failure<UpdateCustomerResponse>($"Customer with id '{request.Id}' was not found.");
    }
    await messaging.PublishAsync(new Message<Customer>(MessageType.Update, customer), CancellationToken.None);
    return Result.Success(customer.ToUpdateCustomerResponse());
  }
}