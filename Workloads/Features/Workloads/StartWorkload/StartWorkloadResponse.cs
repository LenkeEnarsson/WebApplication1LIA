using Workloads.Features.Models;

namespace Workloads.Features.Workloads.StartWorkload;

public sealed class StartWorkloadResponse(
      Guid Id,
      Guid EmployeeId,
      Guid CustomerId,
      DateTimeOffset Start,
      string Notes,
      WorkloadCustomer Customer,
      WorkloadEmployee Employee
  )
{
  public Guid Id { get; } = Id;
  public Guid EmployeeId { get; set; } = EmployeeId;
  public Guid CustomerId { get; set; } = CustomerId;
  public DateTimeOffset Start { get; set; } = Start;
  public string Notes { get; set; } = Notes;
  public WorkloadCustomer Customer { get; set; } = Customer;
  public WorkloadEmployee Employee { get; set; } = Employee;
}