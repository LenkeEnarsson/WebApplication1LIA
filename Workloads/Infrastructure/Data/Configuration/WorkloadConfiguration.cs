using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Workloads.Features.Models;

namespace Workloads.Infrastructure.Data.Configuration;

internal sealed class WorkloadConfiguration
  : IEntityTypeConfiguration<Workload>
{
  public void Configure(EntityTypeBuilder<Workload> builder)
  {
    ArgumentNullException.ThrowIfNull(builder);

    builder.ToTable("Workloads");
    builder.HasKey(w => w.Id);

    builder.Property(c => c.Id).ValueGeneratedNever();
    builder.HasOne(w => w.Customer).WithMany(c => c.Workloads)
          .HasForeignKey(w => w.CustomerId).OnDelete(DeleteBehavior.Restrict);
    builder.HasOne(w => w.Employee).WithMany(e => e.Workloads)
          .HasForeignKey(w => w.EmployeeId).OnDelete(DeleteBehavior.Restrict);
    builder.Property(w => w.Start).IsRequired();
    builder.Property(w => w.Stop);
    builder.Property(w => w.Notes).IsRequired();

    builder.HasIndex(w => new { w.CustomerId, w.Start });
    builder.HasIndex(w => new { w.EmployeeId, w.Start });
  }
}
