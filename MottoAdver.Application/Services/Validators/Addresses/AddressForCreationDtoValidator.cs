using FluentValidation;
using MottoAdver.Application.DataTransferObjects;

namespace MottoAdver.Application.Services.Validators.Addresses;
public class AddressForCreationDtoValidator : AbstractValidator<CreationAddressDto>
{
    public AddressForCreationDtoValidator()
    {
        RuleFor(address => address.country)
            .MaximumLength(50)
            .NotEmpty();

        RuleFor(address => address.region)
            .MaximumLength(50);

        RuleFor(address => address.district)
            .MaximumLength(50);

        RuleFor(address => address.street)
            .MaximumLength(50);
        RuleFor(address => address.postalCode)
            .NotNull();
    }
}
