using MottoAdver.Domain;
using System.ComponentModel.DataAnnotations;

namespace MottoAdver.Application.DataTransferObjects;

public record CreationAddressDto(
    [Required(ErrorMessage = $"{nameof(CreationAddressDto.country)} is required.")]
    [StringLength(50, ErrorMessage = $"The length of the {nameof(CreationAddressDto.country)} must be less than 50")]
    string country,

    [Required(ErrorMessage = $"{nameof(CreationAddressDto.region)} is required.")]
    [StringLength(50, ErrorMessage = $"The length of the {nameof(CreationAddressDto.region)} must be less than 50")]
    string region,

    [Required(ErrorMessage = $"{nameof(CreationAddressDto.district)} is required.")]
    [StringLength(50, ErrorMessage = $"The length of the {nameof(CreationAddressDto.district)} must be less than 50")]
    string district,

    [Required(ErrorMessage = $"{nameof(CreationAddressDto.street)} is required.")]
    [StringLength(50, ErrorMessage = $"The length of the {nameof(CreationAddressDto.street)} must be less than 50")]
    string street,

    [Required(ErrorMessage = "Postal Code is required.")]
    int postalCode);
