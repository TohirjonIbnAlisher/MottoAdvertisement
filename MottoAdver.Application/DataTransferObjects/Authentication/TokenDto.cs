namespace MottoAdver.Application.DataTransferObjects;

public record TokenDto(
    string accessToken,
    string refreshToken,
    DateTime expiredDate);
