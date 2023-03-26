using FluentValidation;
using MottoAdver.Application.DataTransferObjects;

public class AdderessForModificationDtoValidators : AbstractValidator<ModifyAddressDto>
{
    public AdderessForModificationDtoValidators()
    {
        RuleFor(address => address.id)
            .NotNull();

        RuleFor(address => address.country)
            .MaximumLength(50);

        RuleFor(address => address.region)
            .MaximumLength(50);

        RuleFor(address => address.district)
            .MaximumLength(50);

        RuleFor(address => address.street)
            .MaximumLength(50);

    }
}
