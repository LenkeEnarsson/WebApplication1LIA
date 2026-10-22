namespace Messaging.Abstract;

public record Message<T>(MessageType Type, T Payload);

public record CustomerContract(
  Guid Id, 
  string CompanyName, 
  string ContactName, 
  string Street, 
  string PostalCode,
  string City, 
  string Phone
  );
public record EmployeeContract(
  Guid Id, 
  string Title, 
  string GivenName, 
  string Surname, 
  string Street, 
  string PostalCode, 
  string City, 
  string Phone
  );

public record WorkloadContract(
  Guid Id, 
  Guid EmployeeId, 
  Guid CustomerId,
  DateTimeOffset Start, 
  DateTimeOffset? Stop, 
  string Notes
  );