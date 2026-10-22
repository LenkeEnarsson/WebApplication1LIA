using Employees.Features.Employees.CreateEmployee;
using Employees.Features.Employees.DeleteEmployee;
using Employees.Features.Employees.GetAllEmployees;
using Employees.Features.Employees.GetEmployee;
using Employees.Features.Employees.UpdateEmployee;
using Employees.Infrastructure.Data.Context;
using Employees.Infrastructure.Data.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Employees.Infrastructure.Data.Extensions;

public static class EmployeesDbExtensions
{
  extension(IServiceCollection services)
  {
    public IServiceCollection AddEmployeesData(IConfiguration configuration)
    {
      _ = services.AddDbContext<EmployeesContext>((options) =>
      {
        _ = options.UseSqlServer(configuration.GetConnectionString("EmployeeDatabase"));
      });

      _ = services.AddScoped<ICreateEmployeeService, EmployeeService>();
      _ = services.AddScoped<IGetEmployeeService, EmployeeService>();
      _ = services.AddScoped<IGetAllEmployeesService, EmployeeService>();
      _ = services.AddScoped<IUpdateEmployeeService, EmployeeService>();
      _ = services.AddScoped<IDeleteEmployeeService, EmployeeService>();

      return services;
    }
  }

  extension(WebApplication app)
  {
    public WebApplication UseEmployeesData()
    {
      using IServiceScope scope = app.Services.CreateScope();
      EmployeesContext context = scope.ServiceProvider.GetRequiredService<EmployeesContext>();
      if (context.Database.GetPendingMigrations().Any())
      {
        context.Database.Migrate();
      }

      return app;
    }
  }
}