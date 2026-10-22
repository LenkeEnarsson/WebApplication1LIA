using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Workloads.Infrastructure.Data.Context;

internal class WorkloadsContextFactory 
  : IDesignTimeDbContextFactory<WorkloadsContext>
{
  public WorkloadsContext CreateDbContext(string[] args)
  {
    IConfigurationRoot configuration = new ConfigurationBuilder()
      .SetBasePath(Directory.GetCurrentDirectory())
      .AddJsonFile("appsettings.json", optional: true)
      .AddUserSecrets<WorkloadsContextFactory>(optional: true)
      .AddEnvironmentVariables()
      .Build();

    var connectionString = configuration.GetConnectionString("WorkloadDatabase")
      ?? throw new InvalidOperationException("Connection string 'WorkloadDatabase' is required.");

    var options = new DbContextOptionsBuilder<WorkloadsContext>()
        .UseSqlServer(connectionString)
        .Options;

    return new WorkloadsContext(options);
  }
}