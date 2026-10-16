using Customers.Features.Customers.Model;

namespace Customers.Features.Customers.GetAllCustomer;

public interface IGetAllCustomersService
{
    Task<IEnumerable<Customer>> GetAll(CancellationToken cancellationToken = default);
}