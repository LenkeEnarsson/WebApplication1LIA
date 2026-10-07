using Customers.Features.Customers.Model;

namespace Customers.Features.Customers.CreateCustomer
{
    public static class CreateCustomerMappers
    {
        extension(CreateCustomerRequest request)
        {
            public Customer ToCustomer() => new Customer
            {
                CompanyName = request.CompanyName
            };
        }

        extension(Customer customer)
        {
            public CreateCustomerResponse ToCreateCustomerResponse() => new CreateCustomerResponse(
                customer.Id,
                customer.CompanyName
            );
        }
    }
}