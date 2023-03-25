using FluentValidation;
using FluentValidation.Results;
using MottoAdver.Application.DataTransferObjects;
using MottoAdver.Application.Services.Validators.Motos;
using MottoAdver.Domain;
using System.Text.Json;

namespace MottoAdver.Application.Services;
public partial class MotoService
{
    public void ValidationMotoId(Guid motoId)
    {
        if (motoId == default)
        {
            throw new ValidationException($"The given userId is invalid: {motoId}");
        }
    }
    public void ValidationStorageMoto(Motos moto, Guid motoId)
    {
        if (moto == null)
        {
            throw new ValidationException($"Moto object with id:{motoId} is null");
        }
    }
    public void ValidationMotoForCreationDto(CreationMotoDto creationMotoDto)
    {
        var validationResult = new MotoForCreationDtoValidator().Validate(creationMotoDto);

        ThrowValidationExceptionIfValidationIsInvalid(validationResult);
    }
    public void ValidationMotoForModifyDto(ModifyMotoDto modifyMotoDto)
    {
        var validationResult = new MotoForModifyDtoValidator().Validate(modifyMotoDto);

        ThrowValidationExceptionIfValidationIsInvalid(validationResult);
    }
    private static void ThrowValidationExceptionIfValidationIsInvalid(ValidationResult validationResult)
    {
        if (validationResult.IsValid) return;

        var errors = JsonSerializer
            .Serialize(validationResult.Errors.Select(error => new
            {
                PropertyName = error.PropertyName,
                ErrorMessage = "error message",
                AttemptedValue = error.AttemptedValue
            }));

        throw new ValidationException("nimdr");
    }
}
