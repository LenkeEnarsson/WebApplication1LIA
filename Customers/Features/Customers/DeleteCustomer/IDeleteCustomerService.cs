using Customers.Features.Customers.Model;

namespace Customers.Features.Customers.DeleteCustomer;

public interface IDeleteCustomerService
{
  Task<Customer?> Delete(Guid customerId, CancellationToken cancellationToken = default);
}