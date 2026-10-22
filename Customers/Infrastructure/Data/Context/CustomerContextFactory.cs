
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Customers.Infrastructure.Data.Context;

internal class CustomerContextFactory
  : IDesignTimeDbContextFactory<CustomerContext>
{
  public CustomerContext CreateDbContext(string[] args)
  {
    IConfigurationRoot config = new ConfigurationBuilder()
      .SetBasePath(Directory.GetCurrentDirectory())
      .AddUserSecrets<CustomerContextFactory>(optional: true)
      .Build();

    DbContextOptionsBuilder<CustomerContext> optionsbuilder = new();
    _ = optionsbuilder.UseSqlServer(/*"Server=(localdb)\\mssqLLocalDB;Database=CustomersDb;Trusted_Connection=True;TrustServerCertificate=True"*/
      config.GetConnectionString("CustomerDatabase"));

    return new CustomerContext(optionsbuilder.Options);
  }
}
