using Customers.Features.Customers.CreateCustomer;
using Customers.Features.Customers.DeleteCustomer;
using Customers.Features.Customers.GetCustomer;
using Customers.Features.Customers.UpdateCustomer;
using Customers.Infrastructure.Data.Context;
using Customers.Infrastructure.Data.Interceptor;
using Customers.Infrastructure.Data.Services;
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
            _ = services.AddDbContext<CustomerContext>((sp, options) =>
            {
                _ = options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
                _ = options.AddInterceptors(sp.GetRequiredService<CustomerInterceptor>());
            });

            _ = services.AddHttpContextAccessor();
            _ = services.AddSingleton<CustomerInterceptor>();
            _ = services.AddScoped<ICreateCustomerService, CustomerService>();
            _ = services.AddScoped<IGetCustomerService, CustomerService>();
            _ = services.AddScoped<IUpdateCustomerService, CustomerService>();
            _ = services.AddScoped<IDeleteCustomerService, CustomerService>();

            return services;
        }
    }
}