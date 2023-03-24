using MottoAdver.Domain;
using System.IdentityModel.Tokens.Jwt;

namespace MottoAdver.Infastructure.Authentications;

public interface IGenerateJwtToken
{
    JwtSecurityToken GenerateAccessToken(Admins admin);
    string GenerateRefreshToken();
}
