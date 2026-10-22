using Common;
using Customers.Features.Customers.Core;
using Customers.Features.Customers.Model;

namespace Customers.Features.Customers.GetAllCustomer;

public sealed class GetAllCustomersHandler(IGetAllCustomersService getAllCustomersService)
: IRequestHandler<GetAllCustomersRequest, GetAllCustomersResponse>
{
  public async Task<Result<GetAllCustomersResponse>> HandleAsync(GetAllCustomersRequest request)
  {
    IEnumerable<Customer> allCustomers = await getAllCustomersService.GetAll();
    return Result.Success(allCustomers.ToGetAllCustomersResponse());
  }
}