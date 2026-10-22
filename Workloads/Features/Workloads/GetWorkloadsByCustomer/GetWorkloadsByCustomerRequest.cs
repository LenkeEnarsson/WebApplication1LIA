using Common;
using FastEndpoints;

namespace Workloads.Features.Workloads.GetWorkloadsByCustomer;

public sealed class GetWorkloadsByCustomerRequest
    : ICommand<Result<GetWorkloadsByCustomerResponse>>
{
}