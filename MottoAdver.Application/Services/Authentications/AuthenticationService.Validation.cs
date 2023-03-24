using MottoAdver.Domain;
using MottoAdver.Domain.Exceptions;

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
}
