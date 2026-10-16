namespace Customers.Features.Customers.GetAllCustomer;

public sealed record GetAllCustomersResponse(IReadOnlyList<GetAllCustomersResponseItem> Customers);

public record GetAllCustomersResponseItem(Guid id, string CompanyName);