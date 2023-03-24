namespace MottoAdver.Application.DataTransferObjects;

public record RefreshTokenDto(
    string refreshToken,
    string accessToken);
