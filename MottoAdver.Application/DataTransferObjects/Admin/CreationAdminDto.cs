using System.ComponentModel.DataAnnotations;

namespace MottoAdver.Application.DataTransferObjects;
public record CreationAdminDto(
    [Required(ErrorMessage = $"{nameof(CreationAdminDto.fullName)} is required.")]
    [StringLength(50, ErrorMessage = $"The length of the {nameof(CreationAdminDto.fullName)} must be less than 50")]
    string fullName,

    [Required(ErrorMessage = $"{nameof(CreationAdminDto.email)} is required.")]
    [StringLength(30, ErrorMessage = $"The length of the {nameof(CreationAdminDto.email)} must be less than 30")]
    string email,

    [Required(ErrorMessage = $"{nameof(CreationAdminDto.password)} is required.")]
    string password,

    [Required(ErrorMessage = $"{nameof(CreationAdminDto.telegramUserName)} is required.")]
    [StringLength(7, ErrorMessage = $"The length of the {nameof(CreationAdminDto.telegramUserName)} must be less than 7")]
    string telegramUserName,

    [Required(ErrorMessage = $"{nameof(CreationAdminDto.tellNumber)} is required.")]
    [StringLength(20, ErrorMessage = $"The length of the {nameof(CreationAdminDto.tellNumber)} must be less than 20")]
    string tellNumber);
