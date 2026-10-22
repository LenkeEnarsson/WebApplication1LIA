using Microsoft.EntityFrameworkCore;
using Workloads.Features.Models;

namespace Workloads.Infrastructure.Data.Context;

internal class WorkloadsContext(DbContextOptions<WorkloadsContext> options)
  : DbContext(options)
{
  public DbSet<Workload> Workloads => Set<Workload>();
  public DbSet<WorkloadCustomer> WorkloadCustomers => Set<WorkloadCustomer>();
  public DbSet<WorkloadEmployee> WorkloadEmployees => Set<WorkloadEmployee>();

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.ApplyConfigurationsFromAssembly(typeof(WorkloadsContext).Assembly);

    base.OnModelCreating(modelBuilder);
  }
}
