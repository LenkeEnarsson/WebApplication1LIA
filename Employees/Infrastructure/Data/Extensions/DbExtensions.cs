using Employees.Features.Employees.GetEmployee;
using Employees.Infrastructure.Data.Context;
using Employees.Infrastructure.Data.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApplication3.Features.Employees.CreateEmployee;
using WebApplication3.Features.Employees.DeleteEmployee;
using WebApplication3.Features.Employees.GetAllEmployees;
using WebApplication3.Features.Employees.UpdateEmployee;

namespace Employees.Infrastructure.Data.Extensions;

public static class DbExtensions
{
  extension(IServiceCollection services)
  {
    public IServiceCollection AddEmployeesData(IConfiguration configuration)
    {
      _ = services.AddDbContext<EmployeeContext>((options) =>
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
      EmployeeContext context = scope.ServiceProvider.GetRequiredService<EmployeeContext>();
      if (context.Database.GetPendingMigrations().Any())
      {
        context.Database.Migrate();
      }

      return app;
    }
  }
}