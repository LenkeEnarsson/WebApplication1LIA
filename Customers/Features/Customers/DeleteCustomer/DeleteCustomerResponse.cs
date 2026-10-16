using Customers.Features.Customers.Model;

namespace Customers.Features.Customers.DeleteCustomer
{
    public record DeleteCustomerResponse(
      Guid id,
      string CompanyName,
      string OrganizationNumber,
      string ContactName,
      string Street,
      string PostalCode,
      string City,
      string Phone
      );
}