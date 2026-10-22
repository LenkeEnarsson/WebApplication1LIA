using Customers.Features.Customers.Model;

namespace Customers.Features.Customers.CreateCustomer
{
  public interface ICreateCustomerService
  {
    Task<Customer> Create(Customer request, CancellationToken cancellationToken = default);
  }
}