using MottoAdver.Application.DataTransferObjects;
using MottoAdver.Domain;
using MottoAdver.Infastructure.Authentications;

namespace MottoAdver.Application.MappingFactories;

internal static class AdminFactory
{

    internal static Admins MapToAdmin(
        CreationAdminDto creationAdminDto,
        IGeneratePassword generatePassword)
    {
        var passwordSalt = Guid.NewGuid().ToString();
        Admins admin = new Admins
        {
            FullName = creationAdminDto.fullName,
            Email = creationAdminDto.email,
            PasswordHash = generatePassword.GeneratePasswords(
                creationAdminDto.password,
                passwordSalt),
            PasswordSalt = passwordSalt,
            TellNumber = creationAdminDto.tellNumber,
            TelegramUserName = creationAdminDto.telegramUserName,
        };

        return admin;
    }

    internal static void MapToAdmin(
        ModifyAdminDto modifyAdminDto,
        Admins admin)
    {
        admin.FullName = modifyAdminDto.fullName ?? admin.FullName;
        admin.TelegramUserName = modifyAdminDto.telegramUserName ?? admin.TelegramUserName;
        admin.TellNumber = modifyAdminDto.tellNumber ?? admin.TellNumber;
    }

    internal static AdminDto MapToAdminDto(
        Admins admins)
    {
        AdminDto adminDto = new AdminDto(
            id: admins.Id,
            fullName: admins.FullName,
            email: admins.Email,
            telegramUserName: admins.TelegramUserName,
            tellNumber: admins.TellNumber);

        return adminDto;    
    }
}
