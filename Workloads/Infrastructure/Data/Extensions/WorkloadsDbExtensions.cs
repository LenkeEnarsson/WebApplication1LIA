using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Workloads.Features.WorkloadCustomers.GetAllWorkloadCustomers;
using Workloads.Features.WorkloadCustomers.HandleChanges;
using Workloads.Features.WorkloadEmployees.GetAllWorkloadEmployees;
using Workloads.Features.WorkloadEmployees.HandleChanges;
using Workloads.Features.Workloads.GetWorkloadsByCustomer;
using Workloads.Features.Workloads.GetWorkloadsByEmployee;
using Workloads.Features.Workloads.StartWorkload;
using Workloads.Features.Workloads.StopWorkload;
using Workloads.Infrastructure.Data.Context;
using Workloads.Infrastructure.Data.Services;

namespace Workloads.Infrastructure.Data.Extensions;

public static class WorkloadsDbExtensions
{
  extension(IServiceCollection services)
  {
    public IServiceCollection AddWorkloadsData(IConfiguration configuration)
    {
      var connectionString = configuration.GetConnectionString("WorkloadDatabase")
        ?? throw new InvalidOperationException("Connection string 'WorkloadsDatabase' is required.");

      services.AddDbContext<WorkloadsContext>(options => options.UseSqlServer(connectionString));

      services.AddScoped<IWorkloadCustomerEventService, WorkloadService>();
      services.AddScoped<IWorkloadEmployeeEventService, WorkloadService>();
      services.AddScoped<IGetAllWorkloadCustomersService, WorkloadService>();
      services.AddScoped<IGetAllWorkloadEmployeesService, WorkloadService>();
      services.AddScoped<IStartWorkloadService, WorkloadService>();
      services.AddScoped<IStopWorkloadService, WorkloadService>();
      services.AddScoped<IGetWorkloadsByCustomerService, WorkloadService>();
      services.AddScoped<IGetWorkloadsByEmployeeService, WorkloadService>();

      return services;
    }
  }

  extension(WebApplication app)
  {
    public WebApplication UseWorkloadsData()
    {
      using IServiceScope scope = app.Services.CreateScope();
      WorkloadsContext context = scope.ServiceProvider.GetRequiredService<WorkloadsContext>();
      if (context.Database.GetPendingMigrations().Any())
      {
        context.Database.Migrate();
      }

      return app;
    }
  }
}