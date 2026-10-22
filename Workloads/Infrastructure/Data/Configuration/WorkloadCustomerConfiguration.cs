using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Workloads.Features.Models;

namespace Workloads.Infrastructure.Data.Configuration;

internal class WorkloadCustomerConfiguration
    : IEntityTypeConfiguration<WorkloadCustomer>
{
  public void Configure(EntityTypeBuilder<WorkloadCustomer> builder)
  {
    ArgumentNullException.ThrowIfNull(builder);

    builder.ToTable("WorkloadCustomers");
    builder.HasKey(c => c.Id);
    builder.Property(c => c.Id).ValueGeneratedNever();
    builder.Property(c => c.CompanyName).IsRequired();
  }
}