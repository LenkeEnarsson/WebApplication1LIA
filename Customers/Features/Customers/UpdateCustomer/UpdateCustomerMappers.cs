using Customers.Features.Customers.Model;
using Customers.Features.Customers.UpdateCustomer;

public static class UpdateCustomerMappers
{
    extension(UpdateCustomerRequest request)
    {
        public Customer ToCustomer() => new Customer
        {
            Id = request.Id,
            CompanyName = request.CompanyName
        };
    }

    extension(Customer customer)
    {
        public UpdateCustomerResponse ToUpdateCustomerResponse() => new UpdateCustomerResponse(
            customer.Id,
            customer.CompanyName
        );
    }
}