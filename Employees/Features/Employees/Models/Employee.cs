using Common;

namespace Employees.Features.Employees.Models;

public sealed class Employee : EntityBase
{
  public required string SSID { get; set; }
  public required string Title { get; set; }
  public required string GivenName { get; set; }
  public required string Surname { get; set; }
  public required string Street { get; set; }
  public required string PostalCode { get; set; }
  public required string City { get; set; }
  public required string Phone { get; set; }
}