using Common;

namespace Customers.Features.Customers.Core;

public interface IRequestHandler<TRequest, TResponse>
{
  Task<Result<TResponse>> HandleAsync(TRequest request);
}

