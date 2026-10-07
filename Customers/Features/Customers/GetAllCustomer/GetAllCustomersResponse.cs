using System.Collections;

namespace Customers.Features.Customers.GetAllCustomer;

public sealed class GetAllCustomersResponse(IEnumerable<GetAllCustomersResponseItem> customers)
    : IEnumerable<GetAllCustomersResponseItem>
{
    private readonly IEnumerable<GetAllCustomersResponseItem> customers = customers;

    public IEnumerator<GetAllCustomersResponseItem> GetEnumerator() => customers.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public record GetAllCustomersResponseItem(Guid id, string CompanyName);