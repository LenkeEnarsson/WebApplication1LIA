namespace Employees.Infrastructure.Data.Context;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

public class EmployeesContextFactory : IDesignTimeDbContextFactory<EmployeesContext>
{
  public EmployeesContext CreateDbContext(string[] args)
  {
    IConfigurationRoot configuration = new ConfigurationBuilder()
      .SetBasePath(Directory.GetCurrentDirectory())
      .AddUserSecrets<EmployeesContextFactory>(optional: true)
      .Build();

    var optionsBuilder = new DbContextOptionsBuilder<EmployeesContext>();
    optionsBuilder.UseSqlServer(configuration.GetConnectionString("EmployeeDatabase"));

    return new EmployeesContext(optionsBuilder.Options);
  }
}