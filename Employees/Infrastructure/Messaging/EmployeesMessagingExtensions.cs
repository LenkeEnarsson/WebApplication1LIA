using global::Messaging.Abstract;
using global::Messaging.Channels;
using Microsoft.Extensions.DependencyInjection;
using WebApplication3.Features.Employees.Models;

namespace Employees.Infrastructure.Messaging;

public static class EmployeesMessagingExtensions
{
  extension(IServiceCollection services)
  {
    public IServiceCollection AddEmployeeMessaging()
    {
      _=services.AddSingleton<IMessaging<Employee>, ChannelMessaging<Employee>>();
      return services;
    }
  }
}