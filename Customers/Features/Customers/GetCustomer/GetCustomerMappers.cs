using Customers.Features.Customers.Model;

namespace Customers.Features.Customers.GetCustomer;

public static class GetCustomerMappers
{
    extension(Customer customer)
    {
        public GetCustomerResponse ToGetCustomerReponse()
        {
            return new GetCustomerResponse(
            customer.Id,
            customer.CompanyName
        );
        }
    }
}