using FluentValidation;
using MottoAdver.Domain;

namespace MottoAdver.Application.Services.Validators.Motos;
public class MotoForCreationDtoValidator : AbstractValidator<CreationMotoDto>
{
    public MotoForCreationDtoValidator()
    {
        RuleFor(moto => moto)
            .NotNull();

        RuleFor(moto => moto.motoName)
            .MaximumLength(30)
            .NotEmpty();

        RuleFor(moto => moto.charge)
            .MaximumLength(50);

        RuleFor(moto => moto.distanceFullCharge)
            .MaximumLength(50)
            .NotEmpty();

        RuleFor(moto => moto.maxWeight)
            .NotEmpty();

        RuleFor(moto => moto.year)
            .NotEmpty();

        RuleFor(moto => moto.maxSpeed)
            .NotEmpty();

        RuleFor(moto => moto.images)
            .NotNull();
    }
}
