using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication3.Features.Employees.Models;

namespace Employees.Infrastructure.Data.Configuration;

public class EmployeeConfiguration
    : IEntityTypeConfiguration<Employee>
{
  public void Configure(EntityTypeBuilder<Employee> builder)
  {
    ArgumentNullException.ThrowIfNull(builder);

    _ = builder.ToTable("Employees");
    _ = builder.HasKey(e => e.Id);
    _ = builder.Property(e => e.SSID).IsRequired();
    _ = builder.Property(e => e.Title).IsRequired();
    _ = builder.Property(e => e.GivenName).IsRequired();
    _ = builder.Property(e => e.Surname).IsRequired();
    _ = builder.Property(e => e.Street).IsRequired();
    _ = builder.Property(e => e.PostalCode).IsRequired();
    _ = builder.Property(e => e.City).IsRequired();
    _ = builder.Property(e => e.Phone).IsRequired();
  }
}


