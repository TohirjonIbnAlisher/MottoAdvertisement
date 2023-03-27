using FluentValidation;
using MottoAdver.Application.DataTransferObjects;

namespace MottoAdver.Application.Services.Validators.Address;
public class AddressForModifyDtoValidator : AbstractValidator<ModifyAddressDto>
{
    public AddressForModifyDtoValidator()
    {
        RuleFor(add => add)
            .NotNull();

        RuleFor(add => add.id)
            .NotEqual(default(Guid));
    }
}
