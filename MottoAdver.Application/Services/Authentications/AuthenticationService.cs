using MotoAdd.Infastructure.Repositories;
using MottoAdver.Application.DataTransferObjects;
using MottoAdver.Infastructure.Authentications;

namespace MottoAdver.Application.Services;

public partial class AuthenticationService
{
    private readonly IAdminRepository adminRepository;
    private readonly IGeneratePassword generatePassword;
    private readonly IGenerateJwtToken generateJwtToken;

    public AuthenticationService(
        IAdminRepository adminRepository,
        IGeneratePassword generatePassword,
        IGenerateJwtToken generateJwtToken)
    {
        this.adminRepository = adminRepository;
        this.generatePassword = generatePassword;
        this.generateJwtToken = generateJwtToken;
    }

    public async ValueTask<TokenDto> LoginAsync(string username, string password)
    {
        var selectedAdminByEmail = await this.adminRepository.SelectEntityByExpressionAsync(
            admin => admin.Email == username,
            new string[] { });

        VerifyPasswordHasher(password, selectedAdminByEmail);

        var generatedRefreshToken = this.generateJwtToken.GenerateRefreshToken();





    }

    public ValueTask<TokenDto> RefReshTokensAsync(RefreshTokenDto refreshTokenDto)
    {
        throw new NotImplementedException();
    }
}
