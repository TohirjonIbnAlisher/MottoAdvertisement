using MottoAdver.Application.DataTransferObjects;

namespace MottoAdver.Application.Services;

public interface IAuthenticationServices
{
    ValueTask<TokenDto> LoginAsync(LoginDto loginDto);

    ValueTask<TokenDto> RefReshTokensAsync(RefreshTokenDto refreshTokenDto);
}
