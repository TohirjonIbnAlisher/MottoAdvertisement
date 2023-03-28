using FluentValidation;
using MottoAdver.Application.DataTransferObjects;

namespace MottoAdver.Application.Services.Validators.Admins;
public class AdminForCreationDtoValidator : AbstractValidator<CreationAdminDto>
{
    public AdminForCreationDtoValidator()
    {
        RuleFor(admin => admin)
            .NotNull();

        RuleFor(admin => admin.fullName)
            .MaximumLength(50)
            .NotEmpty();

        RuleFor(admin => admin.email)
            .MaximumLength(30)
            .NotEmpty();

        RuleFor(admin => admin.password)
            .NotEmpty();

        RuleFor(admin => admin.telegramUserName)
            .MaximumLength(7)
            .NotEmpty();

        RuleFor(admin => admin.tellNumber)
            .MaximumLength(20)
            .NotEmpty();
    }
}
