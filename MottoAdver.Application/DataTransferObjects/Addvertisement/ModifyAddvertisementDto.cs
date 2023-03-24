namespace MottoAdver.Application.DataTransferObjects;

public record ModifyAddvertisementDto(
    Guid id,
    string? addvertiserFullName,
    string? addvertiserTelegramUserName,
    string? addvertiserTellNumber,
    decimal? price,
    Guid? motoId,
    Guid? addressId);
