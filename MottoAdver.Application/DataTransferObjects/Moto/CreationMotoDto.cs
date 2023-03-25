using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace MottoAdver.Domain;

public record CreationMotoDto(
    [Required(ErrorMessage = $"{nameof(CreationMotoDto.motoName)} is required field.")]
    [StringLength(30, ErrorMessage = $"The length of the {nameof(CreationMotoDto.motoName)} must be greater than 30")]
    string motoName,

    [Required(ErrorMessage = $"{nameof(CreationMotoDto.charge)} is required.")]
    [StringLength(50, ErrorMessage = $"The length of the {nameof(CreationMotoDto.charge)} must be greater than 50")]
    string charge,

    [Required(ErrorMessage = $"{nameof(CreationMotoDto.distanceFullCharge)} is required.")]
    [StringLength(50, ErrorMessage = $"The length of the {nameof(CreationMotoDto.distanceFullCharge)} must be greater than 50")]
    string distanceFullCharge,

    [Required(ErrorMessage = $"{nameof(CreationMotoDto.maxWeight)} is required.")]
    long maxWeight,

    [Required(ErrorMessage = $"{nameof(CreationMotoDto.year)} is required.")]
    int year,

    [Required(ErrorMessage = $"{nameof(CreationMotoDto.maxSpeed)} is required.")]
    int maxSpeed,

    [Required(ErrorMessage = $"{nameof(CreationMotoDto.images)} cannot be null!")]
    ICollection<IFormFile> images);
