using FluentValidation;
using MottoAdver.Application.DataTransferObjects;
using MottoAdver.Domain;

namespace MottoAdver.Application.Services.Validators.Addvertisements;
public class AddvertisementForCreationDtoValidator : AbstractValidator<CreationAddvertisementDto>
{
    public AddvertisementForCreationDtoValidator()
    {
        RuleFor(addvertisement => addvertisement)
            .NotNull();

        RuleFor(addvertisement => addvertisement.addvertiserFullName)
            .MaximumLength(50)
            .NotEmpty();

        RuleFor(addvertisement => addvertisement.addvertiserTelegramUserName)
            .NotEmpty();

        RuleFor(addvertisement => addvertisement.addvertiserTellNumber)
            .MaximumLength(15)
            .NotEmpty();

        RuleFor(addvertisement => addvertisement.price)
            .NotEmpty();

        RuleFor(addvertisement => addvertisement.motoId)
            .NotEqual(default(Guid));

        RuleFor(addvertisement => addvertisement.creationAddressDto)
            .NotNull();
    }
}
