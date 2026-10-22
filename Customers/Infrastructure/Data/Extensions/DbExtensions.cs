using Customers.Features.Customers.CreateCustomer;
using Customers.Features.Customers.DeleteCustomer;
using Customers.Features.Customers.GetCustomer;
using Customers.Features.Customers.UpdateCustomer;
using Customers.Infrastructure.Data.Context;
using Customers.Infrastructure.Data.Interceptor;
using Customers.Infrastructure.Data.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Customers.Infrastructure.Data.Extensions;

public static class DbExtensions
{
  extension(IServiceCollection services)
  {
    public IServiceCollection AddCustomersData(IConfiguration configuration)
    {
      /*
      _ = services.AddDbContext<CustomerContext>((sp, options) =>
      {
        _ = options.UseSqlServer(configuration.GetConnectionString("CustomerDatabase"));
        _ = options.AddInterceptors(sp.GetRequiredService<CustomerInterceptor>());
      });
      */

      _ = services.AddHttpContextAccessor();
      _ = services.AddSingleton<CustomerInterceptor>();
      _ = services.AddScoped<ICreateCustomerService, CustomerService>();
      _ = services.AddScoped<IGetCustomerService, CustomerService>();
      _ = services.AddScoped<IUpdateCustomerService, CustomerService>();
      _ = services.AddScoped<IDeleteCustomerService, CustomerService>();

      return services;
    }
  }

  extension(WebApplication app)
  {
    public WebApplication UseCustomersData()
    {
      using var scope = app.Services.CreateScope();
      var context = scope.ServiceProvider.GetRequiredService<CustomerContext>();

      if (context.Database.GetPendingMigrations().Any())
        context.Database.Migrate();

      return app;
    }
  }
}