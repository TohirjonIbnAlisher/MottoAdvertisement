using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MottoAdver.Domain;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace MottoAdver.Infastructure.Authentications;

public class GenerateJwtToken : IGenerateJwtToken
{
    private readonly JwtOption jwtOption;

    public GenerateJwtToken(IOptions<JwtOption> jwtOption)
    {
        this.jwtOption = jwtOption.Value;
    }

    public JwtSecurityToken GenerateAccessToken(Admins admin)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimNames.Id, admin.Id.ToString()),
            new Claim(ClaimNames.FullName, admin.FullName),
            new Claim(ClaimNames.TellNumber, admin.TellNumber),
            new Claim(ClaimNames.Email, admin.Email),
            new Claim(ClaimNames.TelegramUserName, admin.TelegramUserName)
        };

        var symmetricSecurityKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(this.jwtOption.SecretKey));

        var accessToken = new JwtSecurityToken(
            issuer: this.jwtOption.Issuer,
            audience: this.jwtOption.Audience,
            claims: claims,
            expires: DateTime.Now.AddMinutes(this.jwtOption.ExpirationInMinutes),
            signingCredentials: new SigningCredentials(
                key: symmetricSecurityKey,
                algorithm: SecurityAlgorithms.HmacSha256));

        return accessToken;
    }

    public string GenerateRefreshToken()
    {
        byte[] bytes = new byte[64];

        var randomGenerator = RandomNumberGenerator.Create();

        randomGenerator.GetBytes(bytes);

        return Convert.ToBase64String(bytes);
    }
}
