namespace MottoAdver.Application.DataTransferObjects;

public record AdminDto(
    Guid id,
    string fullName,
    string email,
    long telegramId,
    string tellNumber);
