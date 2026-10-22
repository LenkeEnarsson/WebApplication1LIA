using Common;
using FastEndpoints;

namespace Employees.Features.Employees.GetAllEmployees;

public sealed class GetAllEmployeesRequest
    : ICommand<Result<GetAllEmployeesResponse>>
{
}