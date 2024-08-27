namespace Ordering.Application.Dtos;

public record AddressDto(
    string FirstName,
    String LastName, 
    string EmailAddress, 
    string AddressLine, 
    string Country, 
    string State, 
    string ZipCode);

