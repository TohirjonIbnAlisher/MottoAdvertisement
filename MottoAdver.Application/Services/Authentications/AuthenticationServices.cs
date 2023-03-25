using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MotoAdd.Infastructure.Repositories;
using MottoAdver.Application.DataTransferObjects;
using MottoAdver.Infastructure.Authentications;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MottoAdver.Application.Services;

public partial class AuthenticationServices : IAuthenticationServices
{
    private readonly IAdminRepository adminRepository;
    private readonly IGeneratePassword generatePassword;
    private readonly IGenerateJwtToken generateJwtToken;
    private readonly JwtOption jwtOptions;

    public AuthenticationServices(
        IAdminRepository adminRepository,
        IGeneratePassword generatePassword,
        IGenerateJwtToken generateJwtToken,
        IOptions<JwtOption> options)
    {
        this.adminRepository = adminRepository;
        this.generatePassword = generatePassword;
        this.generateJwtToken = generateJwtToken;
        this.jwtOptions = options.Value;
    }

    public async ValueTask<TokenDto> LoginAsync(string username, string password)
    {
        var selectedAdminByEmail = await this.adminRepository.SelectEntityByExpressionAsync(
            admin => admin.Email == username,
            new string[] { });

        VerifyPasswordHasher(password, selectedAdminByEmail);

        var generatedRefreshToken = this.generateJwtToken.GenerateRefreshToken();

        selectedAdminByEmail.RefreshToken = generatedRefreshToken;

        selectedAdminByEmail.RefreshTokenExpireDate = DateTime.Now.AddDays(5);

        var updatedAdmin = await this.adminRepository.UpdateEntityAsync(selectedAdminByEmail);

        await adminRepository.SaveChangesAsync();

        var generatedAccessToken = this.generateJwtToken.GenerateAccessToken(updatedAdmin);

        return new TokenDto(
            accessToken : new JwtSecurityTokenHandler().WriteToken(generatedAccessToken),
            refreshToken : generatedRefreshToken,
            generatedAccessToken.ValidTo);
    }

    public async ValueTask<TokenDto> RefReshTokensAsync(RefreshTokenDto refreshTokenDto)
    {
        var adminClaimPrinciples = GetPrincipalFromExpiredToken(refreshTokenDto.accessToken);

        var adminId = adminClaimPrinciples.FindFirst(ClaimNames.Id).Value;

        var storageAdmin = await this.adminRepository.SelectEntityByExpressionAsync(
            admin => admin.Id == Guid.Parse(adminId),
            new string[] { });

        ValidateRefreshToken(refreshTokenDto, storageAdmin);

        ValidateRefreshTokenExpireDate(storageAdmin);

        var newAccessToken = this.generateJwtToken.GenerateAccessToken(storageAdmin);

        return new TokenDto(new JwtSecurityTokenHandler().WriteToken(newAccessToken),
            storageAdmin.RefreshToken,
            newAccessToken.ValidTo);
    }

    private ClaimsPrincipal GetPrincipalFromExpiredToken(
        string accessToken)
    {
        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = true,
            ValidAudience = this.jwtOptions.Audience,
            ValidateIssuer = true,
            ValidIssuer = this.jwtOptions.Issuer,
            ValidateLifetime = false,
            ValidateIssuerSigningKey = true,

            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(this.jwtOptions.SecretKey))
        };

        var tokenHandler = new JwtSecurityTokenHandler();

        var principal = tokenHandler.ValidateToken(
            token: accessToken,
            validationParameters: tokenValidationParameters,
            validatedToken: out SecurityToken securityToken);

        var jwtSecurityToken = securityToken as JwtSecurityToken;

        VerifyJwtSecurityToken(jwtSecurityToken);

        return principal;
    }
}
