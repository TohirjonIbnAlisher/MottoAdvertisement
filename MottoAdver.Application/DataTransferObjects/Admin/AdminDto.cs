﻿namespace MottoAdver.Application.DataTransferObjects;

public record AdminDto(
    Guid id,
    string fullName,
    string email,
    string telegramUserName,
    string tellNumber);
