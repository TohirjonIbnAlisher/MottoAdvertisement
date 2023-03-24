namespace MottoAdver.Application.DataTransferObjects;

public record CreationAddressDto(
    string country,
    string region,
    string district,
    string street,
    int postalCode);
