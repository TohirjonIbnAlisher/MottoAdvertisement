using FluentValidation;
using MottoAdver.Application.DataTransferObjects;

namespace MottoAdver.Application.Services.Validators.Motos;
public class MotoForModifyDtoValidator : AbstractValidator<ModifyMotoDto>
{
    public MotoForModifyDtoValidator()
    {
        RuleFor(moto => moto)
            .NotEmpty();

        RuleFor(moto => moto.id)
            .NotEqual(default(Guid));
    }
}
