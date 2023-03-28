using System.ComponentModel.DataAnnotations;

namespace MottoAdver.Application.DataTransferObjects;

public record CreationAddvertisementDto(
    [Required(ErrorMessage = $"{nameof(CreationAddvertisementDto.addvertiserFullName)} is required.")]
    [StringLength(50, ErrorMessage = $"The length of the {nameof(CreationAddvertisementDto.addvertiserFullName)} must be less than 50")]
    string addvertiserFullName,

    [Required(ErrorMessage = $"{nameof(CreationAddvertisementDto.addvertiserTelegramUserName)} is required.")]
    [StringLength(50, ErrorMessage = $"The length of the {nameof(CreationAddvertisementDto.addvertiserTelegramUserName)} must be less than 50")]
    string addvertiserTelegramUserName,

    [Required(ErrorMessage = $"{nameof(CreationAddvertisementDto.addvertiserTellNumber)} is required.")]
    [StringLength(15, ErrorMessage = $"The length of the {nameof(CreationAddvertisementDto.addvertiserTellNumber)} must be less than 15")]
    string addvertiserTellNumber,

    [Required(ErrorMessage = "Price is required.")]
    decimal price,

    [Required(ErrorMessage = "Moto(id) is required.")]
    Guid motoId,

    [Required(ErrorMessage = $"Creation Address-Dto is required.")]
    CreationAddressDto creationAddressDto);
