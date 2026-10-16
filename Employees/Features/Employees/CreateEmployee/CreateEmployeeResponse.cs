namespace Employees.Features.Employees.CreateEmployee;

public sealed class CreateEmployeeResponse(
      Guid id,
      string ssid,
      string title,
      string givenName,
      string surname,
      string street,
      string postalCode,
      string city,
      string phone)
{
  public Guid Id { get; } = id;
  public string SSID { get; set; } = ssid;
  public string Title { get; set; } = title;
  public string GivenName { get; set; } = givenName;
  public string Surname { get; set; } = surname;
  public string Street { get; set; } = street;
  public string PostalCode { get; set; } = postalCode;
  public string City { get; set; } = city;
  public string Phone { get; set; } = phone;
}