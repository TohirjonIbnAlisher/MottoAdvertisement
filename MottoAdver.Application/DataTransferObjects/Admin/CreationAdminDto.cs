namespace MottoAdver.Application.DataTransferObjects;
public record CreationAdminDto(
    string fullName,
    string email,
    string password,
    long telegramId,
    string tellNumber);
