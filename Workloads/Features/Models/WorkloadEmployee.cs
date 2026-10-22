namespace Workloads.Features.Models;

public class WorkloadEmployee
{
  public Guid Id { get; set; }
  public required string FirstName { get; set; }
  public required string LastName { get; set; }
  public ICollection<Workload> Workloads { get; set; } = new HashSet<Workload>();
}
