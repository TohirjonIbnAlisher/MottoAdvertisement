namespace MottoAdver.Application.DataTransferObjects;

public record AddressDto(
    Guid id,
    string country,
    string region,
    string district,
    string street,
    int postalCode);
