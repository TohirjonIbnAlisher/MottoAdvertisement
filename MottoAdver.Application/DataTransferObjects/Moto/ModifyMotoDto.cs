namespace MottoAdver.Application.DataTransferObjects;

public record ModifyMotoDto(
    Guid id,
    string? motoName,
    string? charge,
    string? distanceFullCharge,
    long? maxWeight,
    int? year,
    int? maxSpeed);
