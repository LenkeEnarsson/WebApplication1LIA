using Messaging.Abstract;
using Workloads.Features.Models;

namespace Workloads.Features.Workloads.Mappers;

internal static class WorkloadToContractExtension
{
  extension(Workload workload)
  {
    public WorkloadContract ToContract()
    {
      return new WorkloadContract(
        workload.Id,
        workload.EmployeeId,
        workload.CustomerId,
        workload.Start,
        workload.Stop,
        workload.Notes
      );
    }
  }
}