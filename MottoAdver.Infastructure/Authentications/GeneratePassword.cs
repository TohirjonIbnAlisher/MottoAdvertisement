using System.Security.Cryptography;
using System.Text;

namespace MottoAdver.Infastructure.Authentications;

public class GeneratePassword : IGeneratePassword
{
    public bool VerifyPassword(string password, string salt, string passwordHash)
    {
        var generatedPassword = GeneratePasswords(password, salt);

        return generatedPassword.SequenceEqual(passwordHash);
    }
    // df6d96d4-0f58-4ae9-8306-8e6075b6a1b7
    public string GeneratePasswords(string password, string salt)
    {
        var algorithm = new Rfc2898DeriveBytes(
            password: password,
            salt: Encoding.UTF8.GetBytes(salt),
            iterations: 100,
            hashAlgorithm: HashAlgorithmName.SHA256);

        return Convert.ToBase64String(algorithm.GetBytes(32));
    }
}
