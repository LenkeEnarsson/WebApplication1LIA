using Common;

namespace Employees.Features.Employees.Core;

public interface IRequestHandler<TRequest, TResponse>
{
  Task<Result<TResponse>> HandleAsync(TRequest request, CancellationToken cancellationToken);
}