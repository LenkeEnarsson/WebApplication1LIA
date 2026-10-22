using Customers.Features.Customers.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Customers.Infrastructure.Data.Configuration;

public class CustomerConfiguration
    : IEntityTypeConfiguration<Customer>
{
  public void Configure(EntityTypeBuilder<Customer> builder)
  {
    _ = builder.ToTable("Customers");
    _ = builder.HasKey(e => e.Id);
    _ = builder.Property(e => e.CompanyName).IsRequired();
    _ = builder.Property(e => e.OrganizationNumber).IsRequired();
    _ = builder.Property(e => e.ContactName).IsRequired();
    _ = builder.Property(e => e.Street).IsRequired();
    _ = builder.Property(e => e.PostalCode).IsRequired();
    _ = builder.Property(e => e.City).IsRequired();
    _ = builder.Property(e => e.Phone).IsRequired();
    _ = builder.Property(e => e.Created).IsRequired();
    _ = builder.Property(e => e.Changed).IsRequired();
    _ = builder.Property(e => e.IsDeleted).IsRequired();
    _ = builder.HasQueryFilter(e => !e.IsDeleted);
  }
}