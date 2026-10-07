using Common;
using Customers.Features.Customers.Core;

namespace Customers.Features.Customers.GetAllCustomer;

public sealed class GetAllCustomersHandler(IGetAllCustomerService getAllCustomersService)
: IRequestHandler<GetAllCustomersRequest, GetAllCustomersResponse>
{
    public async Task<Result<GetAllCustomersResponse>> HandleAsync(GetAllCustomersRequest request)
    {
        var allCustomers = await getAllCustomersService.GetAll();
        return Result.Success(allCustomers.ToGetAllCustomersReponse());
    }
}