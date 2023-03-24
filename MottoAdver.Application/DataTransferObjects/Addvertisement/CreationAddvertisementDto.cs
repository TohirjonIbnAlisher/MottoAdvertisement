namespace MottoAdver.Application.DataTransferObjects;

public record CreationAddvertisementDto(
    string addvertiserFullName,
    long addvertiserTelegramId,
    string addvertiserTellNumber,
    decimal price,
    Guid motoId,
    CreationAddressDto creationAddressDto);
