namespace Messaging.Abstract;

public record Message<T>(MessageType Type, T Payload);

public record CustomerContract (Guid id, string CompanyName, string ContactName, string street, string postalcode, string city, string country, string phone);