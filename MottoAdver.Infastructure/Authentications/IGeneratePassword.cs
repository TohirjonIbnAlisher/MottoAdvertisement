namespace MottoAdver.Infastructure.Authentications;

public interface IGeneratePassword
{
    string GeneratePasswords(string password, string salt);

    bool VerifyPassword(string password, string salt, string passwordHash);
}
