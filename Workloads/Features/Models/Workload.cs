namespace Workloads.Features.Models;

public class Workload
{
  public Guid Id { get; set; }
  public required Guid EmployeeId { get; set; }
  public required Guid CustomerId { get; set; }
  public required DateTimeOffset Start { get; set; }
  public DateTimeOffset? Stop { get; set; }
  public string Notes { get; set; } = string.Empty;

  public WorkloadCustomer? Customer { get; set; }
  public WorkloadEmployee? Employee { get; set; }
}