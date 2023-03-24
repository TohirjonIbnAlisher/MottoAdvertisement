using MottoAdver.Application.DataTransferObjects;

namespace MottoAdver.Application.Services;

public interface IAuthenticationService
{
    ValueTask<TokenDto> LoginAsync(string username, string password);

    ValueTask<TokenDto> RefReshTokensAsync(RefreshTokenDto refreshTokenDto);
}
