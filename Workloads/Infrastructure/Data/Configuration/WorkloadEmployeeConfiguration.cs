using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;
using Workloads.Features.Models;

namespace Workloads.Infrastructure.Data.Configuration;

public class WorkloadEmployeeConfiguration
    : IEntityTypeConfiguration<WorkloadEmployee>
{
  public void Configure(EntityTypeBuilder<WorkloadEmployee> builder)
  {
    ArgumentNullException.ThrowIfNull(builder);

      builder.ToTable("WorkloadEmployees");
      builder.HasKey(e => e.Id);

      builder.Property(e => e.Id).ValueGeneratedNever();
      builder.Property(e => e.FirstName).IsRequired();
      builder.Property(e => e.LastName).IsRequired();
  }
}