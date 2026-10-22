using Common;
using FastEndpoints;

namespace Workloads.Features.Workloads.GetWorkloadsByEmployee;

public sealed class GetWorkloadsByEmployeeRequest
    : ICommand<Result<GetWorkloadsByEmployeeResponse>>
{
}