namespace MottoAdver.Application.DataTransferObjects;

public record MotoDto(
    Guid id,
    string motoName,
    string charge,
    string distanceFullCharge,
    long maxWeight,
    int year,
    int maxSpeed);
