namespace MottoAdver.Application.DataTransferObjects;

public record ModifyAdminDto(
    Guid id,
    string? fullName,
    string? telegramUserName,
    string? tellNumber);
