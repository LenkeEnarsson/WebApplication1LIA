using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Workload.Features.Customers.HandleChanges;
using Workload.Features.Employees.HandleChanges;
using Workload.Infrastructure.Data.Services;

namespace Workload.Infrastructure.Data.Extensions;

public static class WorkloadExtensions
{
  extension(IServiceCollection services)
  {
    public IServiceCollection AddWorkloadsData(IConfiguration configuration)
    {
      services.AddTransient<ICustomerEventService, WorkloadService>();
      services.AddTransient<IEmployeeEventService, WorkloadService>();

      return services;
    }
  }
}
