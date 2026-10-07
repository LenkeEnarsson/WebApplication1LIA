using Customers.Features.Customers.Model;

namespace Customers.Features.Customers.GetAllCustomer;

public interface IGetAllCustomerService
{
    Task<IEnumerable<Customer>> GetAll(CancellationToken cancellationToken = default);
}