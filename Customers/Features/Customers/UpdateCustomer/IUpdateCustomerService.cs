using Customers.Features.Customers.Model;

namespace Customers.Features.Customers.UpdateCustomer
{
    public interface IUpdateCustomerService
    {
        Task<Customer> Update(Customer request, CancellationToken cancellationToken = default);
    }
}