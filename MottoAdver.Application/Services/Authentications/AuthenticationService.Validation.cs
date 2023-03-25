using Microsoft.IdentityModel.Tokens;
using MottoAdver.Application.DataTransferObjects;
using MottoAdver.Domain;
using MottoAdver.Domain.Exceptions;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace MottoAdver.Application.Services;

public partial class AuthenticationServices
{
    private void VerifyPasswordHasher(string password, Admins admin) //"c1e212d0-85e8-4ddb-87a2-9d049756307c"
    { 
        if(!generatePassword.VerifyPassword(
            password : password,
            salt : admin.PasswordSalt,
            passwordHash : admin.PasswordHash))
        {
            throw new StrongPasswordVerifierValidation("Error in password");
        }
    }

    private void VerifyJwtSecurityToken(JwtSecurityToken jwtSecurityToken)
    {
        if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(
            SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
        {
            throw new ValidationException("Invalid token");
        }
    }

    private void ValidateRefreshToken(
        RefreshTokenDto refreshTokenDto,
        Admins admins)
    {
        if(!admins.RefreshToken.Equals(refreshTokenDto.refreshToken))
        {
            throw new ValidationException("RefreshToken xato");
        }
    }

    private void ValidateRefreshTokenExpireDate(Admins admin)
    {
        if(admin.RefreshTokenExpireDate < DateTime.Now)
        {
            throw new ValidationException("RefreshToken eskirgan");
        }
    }
}
