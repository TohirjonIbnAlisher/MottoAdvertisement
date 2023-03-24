namespace MottoAdver.Application.DataTransferObjects;

public record ModifyAddvertisementDto(
    Guid id,
    string? addvertiserFullName,
    long? addvertiserTelegramId,
    string? addvertiserTellNumber,
    decimal? price,
    Guid? motoId,
    Guid? addressId);
