using FluentValidation;
using FluentValidation.Results;
using MottoAdver.Application.DataTransferObjects;
using MottoAdver.Application.Services.Validators.Addresses;
using MottoAdver.Domain;
using System.Text.Json;

namespace MottoAdver.Application.Services.Address
{
    public partial class AddressService
    {
        public void ValidationAddressId(Guid Id)
        {
            if (Id == default)
            {
                throw new ValidationException($"The given Id is invalid: {Id}");
            }
        }
        public void ValidationStorageAddress(Addresses address, Guid Id)
        {
            if (address == null)
            {
                throw new System.ComponentModel.DataAnnotations.ValidationException($"Address object with id:{Id} is null");
            }
        }
        public void ValidationMotoForCreationDto(CreationAddressDto creationAddressDto)
        {
            var validationResult = new AddressForCreationDtoValidator().Validate(creationAddressDto);

            ThrowValidationExceptionIfValidationIsInvalid(validationResult);
        }
        public void ValidationAddressForModifyDto(ModifyAddressDto modifyAddressDto)
        {
            var validationResult = new AdderessForModificationDtoValidators().Validate(modifyAddressDto);

            ThrowValidationExceptionIfValidationIsInvalid(validationResult);
        }
        private static void ThrowValidationExceptionIfValidationIsInvalid(ValidationResult validationResult)
        {
            if (validationResult.IsValid) return;

            var errors = JsonSerializer
                .Serialize(validationResult.Errors.Select(error => new
                {
                    PropertyName = error.PropertyName,
                    ErrorMessage = error.ErrorMessage,
                    AttemptedValue = error.AttemptedValue
                }));

            throw new ValidationException(errors);
        }
    }
}
