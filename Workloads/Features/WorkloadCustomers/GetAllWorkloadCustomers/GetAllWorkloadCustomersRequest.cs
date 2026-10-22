using Common;
using FastEndpoints;

namespace Workloads.Features.WorkloadCustomers.GetAllWorkloadCustomers;

public sealed class GetAllWorkloadCustomersRequest
    : ICommand<Result<GetAllWorkloadCustomersResponse>>
{
}