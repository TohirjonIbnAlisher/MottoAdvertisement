namespace MottoAdver.Application.DataTransferObjects;

public record ModifyAddressDto(
    Guid id,
    string? country,
    string? region,
    string? district,
    string? street,
    int? postalCode);
