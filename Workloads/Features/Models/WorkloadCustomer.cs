namespace Workloads.Features.Models;

public class WorkloadCustomer
{
  public Guid Id { get; set; }
  public required string CompanyName { get; set; }
  public ICollection<Workload> Workloads { get; set; } = new HashSet<Workload>();
}
