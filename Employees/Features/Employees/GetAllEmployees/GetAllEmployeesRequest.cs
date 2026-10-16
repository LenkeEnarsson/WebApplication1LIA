using Common;
using FastEndpoints;

namespace WebApplication3.Features.Employees.GetAllEmployees;

public sealed class GetAllEmployeesRequest
    : ICommand<Result<GetAllEmployeesResponse>>
{
}
