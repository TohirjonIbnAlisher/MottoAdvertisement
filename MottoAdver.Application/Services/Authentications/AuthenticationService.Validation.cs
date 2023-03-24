namespace MottoAdver.Application.Services;

public partial class AuthenticationService
{
    private void VerifyPasswordHasher(string password, string salt)
    {
        var generatedPasswordHash = this.generatePassword.GeneratePasswords(password, salt);


    }
}
