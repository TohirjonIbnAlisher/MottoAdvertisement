using FluentValidation;
using MottoAdver.Application.DataTransferObjects;
using MottoAdver.Domain;

namespace MottoAdver.Application.Services.Validators.Addvertisements;
public class AddvertisementForModifyDtoValidator : AbstractValidator<ModifyAddvertisementDto>
{
    public AddvertisementForModifyDtoValidator()
    {
        RuleFor(addvertisement => addvertisement)
            .NotNull();

        RuleFor(addvertisement => addvertisement.id)
            .Equal(default(Guid));
    }
}
