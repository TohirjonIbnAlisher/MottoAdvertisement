using Microsoft.AspNetCore.Http;

namespace MottoAdver.Domain;

public record CreationMotoDto(
    string motoName,
    string charge,
    string distanceFullCharge,
    long maxWeight,
    int year,
    int maxSpeed,
    ICollection<IFormFile> images);
