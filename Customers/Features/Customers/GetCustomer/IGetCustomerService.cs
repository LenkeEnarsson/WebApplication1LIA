using Customers.Features.Customers.Model;

namespace Customers.Features.Customers.GetCustomer;

public interface IGetCustomerService
{
  Task<Customer?> Get(Guid customerId, CancellationToken cancellationToken = default);
}