﻿using MottoAdver.Application.DataTransferObjects;
using MottoAdver.Domain;

namespace MottoAdver.Application.MappingFactories;

internal static class AdminFactory
{
    internal static Admins MapToAdmin(CreationAdminDto creationAdminDto)
    {
        Admins admin = new Admins
        {
            FullName = creationAdminDto.fullName,
            Email = creationAdminDto.email,
            PasswordHash = creationAdminDto.password,
            PasswordSalt = Guid.NewGuid().ToString(),
            TellNumber = creationAdminDto.tellNumber,
            TelegramId = creationAdminDto.telegramId,
        };

        return admin;
    }

    internal static void MapToAdmin(
        ModifyAdminDto modifyAdminDto,
        Admins admin)
    {
        admin.FullName = modifyAdminDto.fullName ?? admin.FullName;
        admin.TelegramId = modifyAdminDto.telegramId ?? admin.TelegramId;
        admin.TellNumber = modifyAdminDto.tellNumber ?? admin.TellNumber;
    }

    internal static AdminDto MapToAdminDto(
        Admins admins)
    {
        AdminDto adminDto = new AdminDto(
            id: admins.Id,
            fullName: admins.FullName,
            email: admins.Email,
            telegramId: admins.TelegramId,
            tellNumber: admins.TellNumber);

        return adminDto;    
    }
}