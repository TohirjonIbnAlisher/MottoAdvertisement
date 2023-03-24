using MottoAdver.Domain;

namespace MottoAdver.Application.DataTransferObjects;

public record AddvertisementDto(
    Guid id,
    string addvertiserFullName,
    long addvertiserTelegramId,
    string addvertiserTellNumber,
    decimal price,
    MotoDto motoDto = null,
    AddressDto addressDto = null);
