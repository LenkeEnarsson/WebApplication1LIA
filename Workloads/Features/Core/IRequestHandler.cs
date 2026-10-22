using Common;

namespace Workloads.Features.Core;

public interface IRequestHandler<TRequest, TResponse>
{
  Task<Result<TResponse>> HandleAsync(TRequest request);
}