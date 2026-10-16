using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Customers.Infrastructure.Data.Context;

internal class CustomerContextFactory
  : IDesignTimeDbContextFactory<CustomerContext>
{
  public CustomerContext CreateDbContext(string[] args)
  {
    IConfigurationRoot config = new ConfigurationBuilder()
      .SetBasePath(Directory.GetCurrentDirectory())
      .AddUserSecrets<CustomerContextFactory>()
      .Build();

    var optionsbuilder = new DbContextOptionsBuilder<CustomerContext>();
    optionsbuilder.UseSqlServer(config.GetConnectionString("CustomersConnection"));

    return new CustomerContext(optionsbuilder.Options);
  }

}
