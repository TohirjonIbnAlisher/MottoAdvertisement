﻿using Microsoft.IdentityModel.Tokens;
using MottoAdver.Domain;
using MottoAdver.Domain.Exceptions;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace MottoAdver.Application.Services;

public partial class AuthenticationService
{
    private void VerifyPasswordHasher(string password, Admins admin)
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
}
