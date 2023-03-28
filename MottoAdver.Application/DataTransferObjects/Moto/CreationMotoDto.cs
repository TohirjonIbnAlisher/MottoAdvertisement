using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace MottoAdver.Domain;

public record CreationMotoDto(
    [Required(ErrorMessage = $"{nameof(CreationMotoDto.motoName)} is required.")]
    [StringLength(50, ErrorMessage = $"The length of the {nameof(CreationMotoDto.motoName)} must be less than 50")]
    string motoName,

    [Required(ErrorMessage = $"{nameof(CreationMotoDto.charge)} is required.")]
    [StringLength(50, ErrorMessage = $"The length of the {nameof(CreationMotoDto.charge)} must be less than 50")]
    string charge,

    [Required(ErrorMessage = $"{nameof(CreationMotoDto.distanceFullCharge)} is required.")]
    [StringLength(50, ErrorMessage = $"The length of the {nameof(CreationMotoDto.distanceFullCharge)} must be less than 50")]
    string distanceFullCharge,

    [Required(ErrorMessage = "Max weight is required.")]
    long maxWeight,

    [Required(ErrorMessage = "Year is required.")]
    int year,

    [Required(ErrorMessage = "Max speed is required.")]
    int maxSpeed,

    [Required(ErrorMessage = "Images cannot be null!")]
    ICollection<IFormFile> images);
