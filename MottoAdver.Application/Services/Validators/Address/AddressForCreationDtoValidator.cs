using FluentValidation;
using MottoAdver.Application.DataTransferObjects;

namespace MottoAdver.Application.Services.Validators.Address;
public class AddressForCreationDtoValidator : AbstractValidator<CreationAddressDto>
{
    public AddressForCreationDtoValidator()
    {
        RuleFor(add => add)
            .NotNull();

        RuleFor(add => add.country)
            .MaximumLength(50)
            .NotEmpty();

        RuleFor(add => add.region)
            .MaximumLength(50)
            .NotEmpty();

        RuleFor(add => add.district)
            .MaximumLength(50)
            .NotEmpty();

        RuleFor(add => add.street)
            .MaximumLength(50)
            .NotEmpty();

        RuleFor(add => add.postalCode)
            .NotEmpty();
    }
}
