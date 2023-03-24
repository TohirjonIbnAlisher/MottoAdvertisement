namespace MottoAdver.Application.DataTransferObjects;
public record CreationAdminDto(
    string fullName,
    string email,
    string password,
    string telegramUserName,
    string tellNumber);
