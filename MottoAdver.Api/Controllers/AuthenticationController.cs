using Microsoft.AspNetCore.Mvc;
using MottoAdver.Application.DataTransferObjects;
using MottoAdver.Application.Services;

namespace MottoAdver.Api.Controllers;

[ApiController]
[Route("api/authentication")]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthenticationServices authenticationService;

    public AuthenticationController(
        IAuthenticationServices authenticationService)
    {
        this.authenticationService = authenticationService;
    }

    [HttpPost("Login")]
    public async ValueTask<ActionResult<TokenDto>> LoginAsync(
        LoginDto loginDto)
    {
        var tokenDto = await this.authenticationService.LoginAsync(loginDto);

        return Created("", tokenDto);
    }

    [HttpPost("RefreshToken")]
    public async ValueTask<ActionResult<TokenDto>> RefreshTokenAsync(
        [FromBody]RefreshTokenDto refreshTokenDto)
    {
        var refreshedToken = await this.authenticationService.RefReshTokensAsync(refreshTokenDto);

        return Created("", refreshedToken);
    }
}
