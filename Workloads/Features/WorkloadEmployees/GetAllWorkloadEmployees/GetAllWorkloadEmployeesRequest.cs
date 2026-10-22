using Common;
using FastEndpoints;

namespace Workloads.Features.WorkloadEmployees.GetAllWorkloadEmployees;

public sealed class GetAllWorkloadEmployeesRequest
    : ICommand<Result<GetAllWorkloadEmployeesResponse>>
{
}