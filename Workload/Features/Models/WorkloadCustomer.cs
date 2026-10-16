using System;
using System.Collections.Generic;
using System.Text;

namespace Workload.Features.Models;

internal class WorkloadCustomer
{
  public Guid Id { get; set; }
  public required string CompanyName { get; set; }
  public ICollection<Workload> Workloads { get; set; } = new HashSet<Workload>();
}

internal class WorkLoadEmployee
{
  public Guid Id { get; set; }
  public required string GivenName { get; set; }
  public required string Surname { get; set; }
  public ICollection<Workload> Workloads { get; set; } = new HashSet<Workload>();
}

internal class Workload
{
  public Guid Id { get; set; }
  public required Guid EmployeeId { get; set; }
  public required Guid CustomerId { get; set; }
  public required DateTimeOffset Start { get; set; }
  public DateTimeOffset End { get; set; }
  public string Notes { get; set; } = string.Empty;

  public WorkloadCustomer? Customer { get; set; }
  public WorkLoadEmployee? Employee { get; set; }
}