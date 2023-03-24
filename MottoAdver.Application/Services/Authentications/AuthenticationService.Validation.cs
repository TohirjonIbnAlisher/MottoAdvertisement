using MottoAdver.Domain;

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

        }
    }
}
