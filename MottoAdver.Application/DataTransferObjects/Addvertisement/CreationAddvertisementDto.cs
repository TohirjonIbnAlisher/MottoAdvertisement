namespace MottoAdver.Application.DataTransferObjects;

public record CreationAddvertisementDto(
    string addvertiserFullName,
    string addvertiserTelegramUserName,
    string addvertiserTellNumber,
    decimal price,
    Guid motoId,
    CreationAddressDto creationAddressDto);
