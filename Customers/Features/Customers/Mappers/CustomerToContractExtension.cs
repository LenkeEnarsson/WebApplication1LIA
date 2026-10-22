using Customers.Features.Customers.Model;
using Messaging.Abstract;

namespace Customers.Features.Customers.Mappers;

internal static class CustomerToContractExtension
{
  extension(Customer customer)
  {
    public CustomerContract ToContract()
    {
      return new CustomerContract(
        customer.Id,
        customer.CompanyName,
        customer.ContactName,
        customer.Street,
        customer.PostalCode,
        customer.City,
        customer.Phone
      );
    }
  }
}

