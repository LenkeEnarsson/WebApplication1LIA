using Customers.Features.Customers.Model;

namespace Customers.Features.Customers.GetAllCustomer
{
    public static class GetAllCustomersMappers
    {
        extension(IEnumerable<Customer> customers)
        {
            public GetAllCustomersResponse ToGetAllCustomersReponse() => 
                new(customers.Select(customer => new GetAllCustomersResponseItem(
                customer.Id,
                customer.CompanyName
            )));
        }
    }
}